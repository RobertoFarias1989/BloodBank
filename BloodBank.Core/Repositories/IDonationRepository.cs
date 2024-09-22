using BloodBank.Core.Entities;
using BloodBank.Core.Models;

namespace BloodBank.Core.Repositories;

public interface IDonationRepository
{
    Task<PaginationResult<Donation>> GetAllAsync(int page = 1);
    Task<Donation?> GetByIdAsync(int id);
    Task<Donation?> GetDetailsByIdAsync(int id);
    Task AddAsync(Donation donation);
    Task UpdateAsync(Donation donation);
    Task SaveChangesAsync();
}
