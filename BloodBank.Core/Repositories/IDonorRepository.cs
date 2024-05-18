using BloodBank.Core.Entities;

namespace BloodBank.Core.Repositories
{
    public interface IDonorRepository
    {
        Task<List<Donor>> GetAllAsync();
        Task<Donor> GetByIdAsync(int id);
        Task<Donor> GetDetailsByIdAsync(int id);
        Task AddAsync(Donor donor);
        Task SaveChangesAsync();
    }
}
