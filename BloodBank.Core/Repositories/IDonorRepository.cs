using BloodBank.Core.Entities;

namespace BloodBank.Core.Repositories;

public interface IDonorRepository
{
    Task<List<Donor>> GetAllAsync();
    Task<Donor?> GetByIdAsync(int id);
    Task<Donor?> GetDetailsByIdAsync(int id);
    Task<Donor?> GetDonorByEmailAndPassword(string email, string password);
    Task AddAsync(Donor donor);
    Task UpdateAsync(Donor donor);
    Task SaveChangesAsync();
}
