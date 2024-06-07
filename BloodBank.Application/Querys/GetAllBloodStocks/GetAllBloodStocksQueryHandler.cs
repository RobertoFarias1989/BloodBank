using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Querys.GetAllBloodStocks;

public class GetAllBloodStocksQueryHandler : IRequestHandler<GetAllBloodStocksQuery, List<BloodStockViewModel>>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetAllBloodStocksQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<BloodStockViewModel>> Handle(GetAllBloodStocksQuery request, CancellationToken cancellationToken)
    {
        var bloodStock = await _unitOfWork.BloodStockRepository.GetAllAsync();

        var bloodStockViewModel = bloodStock
            .Select(bs => new BloodStockViewModel(
                id:bs.Id,
                bloodType: bs.BloodType.ToString(),
                rHFactor: bs.RHFactor.ToString(),
                validateUntil: bs.ValidateUntil.ToShortDateString(),
                idDonation: bs.IdDonation))
            .ToList();

        return bloodStockViewModel;
    }
}
