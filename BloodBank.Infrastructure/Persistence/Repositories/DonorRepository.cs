using BloodBank.Core.Entities;
using BloodBank.Core.Models;
using BloodBank.Core.Repositories;
using BloodBank.Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories;

public class DonorRepository : IDonorRepository
{
    private readonly BloodBankDbContext _dbContext;
    private const int PAGE_SIZE = 2;

    public DonorRepository(BloodBankDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationResult<Donor>> GetAllAsync(string query, int page)
    {
        //Utilizar o AsNoTracking significa que as entidades serão lidas da origem de dados mas não serão mantidas no contexto.
        //return await _dbContext.Donors.AsNoTracking().ToListAsync();

        IQueryable<Donor> donors = _dbContext.Donors;

        if (!string.IsNullOrEmpty(query))
        {
            donors = donors
                .Where(d => 
                d.Name.FullName.Contains(query)
                || d.RHFactor.ToString().Contains(query)
                || d.Gender.ToString().Contains(query)
                || d.Role.Contains(query));
        }

        return await donors.GetPaged<Donor>(page, PAGE_SIZE);
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
