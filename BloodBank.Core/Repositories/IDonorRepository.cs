using BloodBank.Core.Entities;
using BloodBank.Core.Models;

namespace BloodBank.Core.Repositories;

public interface IDonorRepository
{
    Task<PaginationResult<Donor>> GetAllAsync(string query, int page = 1);
    Task<Donor?> GetByIdAsync(int id);
    Task<Donor?> GetDetailsByIdAsync(int id);
    Task<Donor?> GetDonorByEmailAndPassword(string email, string password);
    Task AddAsync(Donor donor);
    Task UpdateAsync(Donor donor);
    Task SaveChangesAsync();
}
