using BloodBank.Core.Entities;

namespace BloodBank.Core.Repositories;

public interface IDonationRepository
{
    Task<List<Donation>> GetAllAsync();
    Task<Donation> GetByIdAsync(int id);
    Task<Donation> GetDetailsByIdAsync(int id);
    Task AddAsync(Donation donation);
    Task UpdateAsync(Donation donation);
    Task SaveChangesAsync();
}
