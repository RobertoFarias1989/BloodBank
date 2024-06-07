using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Repositories;

public interface IUnitOfWork
{
    IBloodStockRepository BloodStockRepository { get; }
    IDonationRepository DonationRepository { get; }
    IDonorRepository DonorRepository { get; }
    Task<int> CompletAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();

}
