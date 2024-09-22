using BloodBank.Core.Entities;
using BloodBank.Core.Enums;
using BloodBank.Core.Models;

namespace BloodBank.Core.Repositories;

public interface IBloodStockRepository
{
    Task<PaginationResult<BloodStock>> GetAllAsync(string query, int page = 1);
    Task<List<BloodStock>> GetAllAsync();
    Task<BloodStock?> GetByIdAsync(int id);
    Task<BloodStock?> GetByIdAsync(BloodTypeEnum bloodType, RHFactorEnum factorRH);
    Task<BloodStock?> GetDetailsById(int id);
    Task AddAsync(BloodStock bloodStock);
    Task UpdateAsync(BloodStock bloodStock);
    Task SaveChangesAsync();
}
