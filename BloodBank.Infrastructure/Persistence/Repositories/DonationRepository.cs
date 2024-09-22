using BloodBank.Core.Entities;
using BloodBank.Core.Models;
using BloodBank.Core.Repositories;
using BloodBank.Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories;

public class DonationRepository : IDonationRepository
{
    private readonly BloodBankDbContext _dbContext;
    private const int PAGE_SIZE = 2;

    public DonationRepository(BloodBankDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationResult<Donation>> GetAllAsync(int page)
    {
        //Utilizar o AsNoTracking significa que as entidades serão lidas da origem de dados mas não serão mantidas no contexto.
        //return await _dbContext.Donations.AsNoTracking().ToListAsync();

        IQueryable<Donation> donations = _dbContext.Donations;

        return await donations.GetPaged<Donation>(page, PAGE_SIZE);    
    }

    public async Task<Donation?> GetByIdAsync(int id)
    {
        return await _dbContext
            .Donations
            .AsNoTracking()
            .SingleOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Donation?> GetDetailsByIdAsync(int id)
    {
        return await _dbContext
            .Donations
            .AsNoTracking()
            .SingleOrDefaultAsync(d => d.Id == id);
    }

    public async Task AddAsync(Donation donation)
    {
        await _dbContext.Donations.AddAsync(donation);
       
    }
    public async Task UpdateAsync(Donation donation)
    {
         _dbContext.Donations.Update(donation);
       
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }


}
