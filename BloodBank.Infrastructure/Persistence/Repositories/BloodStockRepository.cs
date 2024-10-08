﻿using BloodBank.Core.Entities;
using BloodBank.Core.Enums;
using BloodBank.Core.Models;
using BloodBank.Core.Repositories;
using BloodBank.Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories;

public class BloodStockRepository : IBloodStockRepository
{
  
    private readonly BloodBankDbContext _dbContext;
    private const int PAGE_SIZE = 2;

    public BloodStockRepository(BloodBankDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationResult<BloodStock>> GetAllAsync(string query, int page)
    {
        IQueryable<BloodStock> bloodStocks = _dbContext.BloodStocks;

        if (!string.IsNullOrWhiteSpace(query))
        {
            bloodStocks = bloodStocks
                .Where(bs =>
                    bs.RHFactor.ToString().Contains(query)
                    || bs.BloodType.ToString().Contains(query));
        }

        return await bloodStocks.GetPaged<BloodStock>(page, PAGE_SIZE);

    }
    public async Task<List<BloodStock>> GetAllAsync()
    {
        //Com o AsNoTracking ocorre a leitura da entidade mas não o seu armazenamento em cache
        //fazendo assim não sobrecarregamos nossa aplicação de forma desnecessária
        //Importante dizer que não podemos atualizar uma entidade sem que ele esteja armazenada no contexto
        //ou seja, para atualizá-la não poderemos utilizar o AsNoTracking
        return await _dbContext.BloodStocks.AsNoTracking().ToListAsync();
    }

    public async Task<BloodStock?> GetByIdAsync(int id)
    {
        return await _dbContext
            .BloodStocks
            .AsNoTracking()
            .SingleOrDefaultAsync(b => b.IdDonation == id);
    }

    public async Task<BloodStock?> GetDetailsById(int id)
    {
        return await _dbContext
            .BloodStocks
            .AsNoTracking()
            .SingleOrDefaultAsync(b => b.Id == id);
    }

    public async Task<BloodStock?> GetByIdAsync(BloodTypeEnum bloodType, RHFactorEnum factorRH)
    {
        return await _dbContext.BloodStocks
            .AsNoTracking()
            .SingleOrDefaultAsync(b => b.BloodType == bloodType && b.RHFactor == factorRH);
    }

    public async Task AddAsync(BloodStock bloodStock)
    {
        await _dbContext.BloodStocks.AddAsync(bloodStock);

        //Como agora estamos usando o UNitOfWork não é mais necessário chamarmos o SaveChanges aqui
        //await SaveChangesAsync();
    }

    public async Task UpdateAsync(BloodStock bloodStock)
    {
        // o update muda o estado da entidade para modificado
        //assim as alterações são persistidas quando chamamos o SaveChanges
        _dbContext.BloodStocks.Update(bloodStock);

        //outra forma de se fazer o processo acima
        //marcamos o estado da entidade como modificado
        //para que assim as alterações seja persistidas pelo SaveChanges
        /*_dbContext.Entry(bloodStock).State = EntityState.Modified;*/

        //await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

}
