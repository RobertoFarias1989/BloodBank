using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories;

public class BloodStockRepository : IBloodStockRepository
{
  
    private readonly BloodBankDbContext _dbContext;

    public BloodStockRepository(BloodBankDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<BloodStock>> GetAllAsync()
    {
        //Com o AsNoTracking ocorre a leitura da entidade mas não o seu armazenamento em cache
        //fazendo assim não sobrecarregamos nossa aplicação de forma desnecessária
        //Importante dizer que não podemos atualizar uma entidade sem que ele esteja armazenada no contexto
        //ou seja, para atualizá-la não poderemos utilizar o AsNoTracking
        return await _dbContext.BloodStocks.AsNoTracking().ToListAsync();
    }

    public async Task<BloodStock> GetByIdAsync(int id)
    {
        return await _dbContext
            .BloodStocks
            .AsNoTracking()
            .SingleOrDefaultAsync(b => b.Id == id);
    }

    public async Task<BloodStock> GetDetailsById(int id)
    {
        return await _dbContext
            .BloodStocks
            .AsNoTracking()
            .SingleOrDefaultAsync(b => b.Id == id);
    }

    public async Task AddAsync(BloodStock bloodStock)
    {
        await _dbContext.BloodStocks.AddAsync(bloodStock);
        await SaveChangesAsync();
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

        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

}
