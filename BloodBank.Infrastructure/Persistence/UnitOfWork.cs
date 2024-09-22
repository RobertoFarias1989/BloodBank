using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace BloodBank.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private IDbContextTransaction _transaction;
    private readonly BloodBankDbContext _dbContext;

    public UnitOfWork(BloodBankDbContext dbContext,
        IBloodStockRepository bloodStockRepository,
        IDonationRepository donationRepository, IDonorRepository donorRepository)
    {
        _dbContext = dbContext;
        BloodStockRepository = bloodStockRepository;
        DonationRepository = donationRepository;
        DonorRepository = donorRepository;
    }

    public IBloodStockRepository BloodStockRepository { get; }
    public IDonationRepository DonationRepository { get; }
    public IDonorRepository DonorRepository { get; }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }
        catch (Exception)
        {
            await _transaction.RollbackAsync();

            throw;
        }
    }

    public async Task<int> CompletAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
