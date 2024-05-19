using BloodBank.Application.ViewModels;
using BloodBank.Core.Enums;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Querys.GetAllBloodStocks;

public class GetAllBloodStocksQueryHandler : IRequestHandler<GetAllBloodStocksQuery, List<BloodStockViewModel>>
{
    private readonly IBloodStockRepository _bloodStockRepository;
    public async Task<List<BloodStockViewModel>> Handle(GetAllBloodStocksQuery request, CancellationToken cancellationToken)
    {
        var bloodStock = await _bloodStockRepository.GetAllAsync();

        var bloodStockViewModel = bloodStock
            .Select(bs=> new BloodStockViewModel(
                id:bs.Id,
                bloodType: bs.BloodType.ToString(),
                rHFactor: bs.RHFactor.ToString()))
            .ToList();

        return bloodStockViewModel;
    }
}
