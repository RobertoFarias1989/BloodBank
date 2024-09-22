using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories;

public class DonorRepository : IDonorRepository
{
    private readonly BloodBankDbContext _dbContext;

    public DonorRepository(BloodBankDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Donor>> GetAllAsync()
    {
        //Utilizar o AsNoTracking significa que as entidades serão lidas da origem de dados mas não serão mantidas no contexto.
        return await _dbContext.Donors.AsNoTracking().ToListAsync();
    }

    public async Task<Donor?> GetByIdAsync(int id)
    {
        return await _dbContext
            .Donors
            .AsNoTracking()
            .SingleOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Donor?> GetDetailsByIdAsync(int id)
    {
        return await _dbContext.Donors
            .Include(d=> d.Donations)
            .AsNoTracking()
            .SingleOrDefaultAsync(d => d.Id == id);
    }

    public async Task AddAsync(Donor donor)
    {
        await _dbContext.AddAsync(donor);
        
        
    }

    public async Task UpdateAsync(Donor donor)
    {
        _dbContext.Donors.Update(donor);
        
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Donor?> GetDonorByEmailAndPassword(string email, string password)
    {
        return await _dbContext.Donors
            .SingleOrDefaultAsync(d => d.Email.EmailAddress == email && d.Password.PasswordValue == password);
    }
}
