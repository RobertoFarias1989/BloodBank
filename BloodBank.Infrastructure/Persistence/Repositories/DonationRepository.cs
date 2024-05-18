using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly BloodBankDbContext _dbContext;

        public DonationRepository(BloodBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Donation>> GetAllAsync()
        {
            //Utilizar o AsNoTracking significa que as entidades serão lidas da origem de dados mas não serão mantidas no contexto.
            return await _dbContext.Donations.AsNoTracking().ToListAsync();
        }

        public async Task<Donation> GetByIdAsync(int id)
        {
            return await _dbContext.Donations.SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Donation> GetDetailsByIdAsync(int id)
        {
            return await _dbContext.Donations.SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(Donation donation)
        {
            await _dbContext.Donations.AddAsync(donation);
            SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
