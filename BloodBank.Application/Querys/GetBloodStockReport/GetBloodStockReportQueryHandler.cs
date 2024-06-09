using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Querys.GetBloodStockReport;

public class GetBloodStockReportQueryHandler : IRequestHandler<GetBloodStockReportQuery, List<BloodStockReportViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBloodStockReportQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<BloodStockReportViewModel>> Handle(GetBloodStockReportQuery request, CancellationToken cancellationToken)
    {
        var bloodStock = await _unitOfWork.BloodStockRepository.GetAllAsync();

        var bloodStockReportViewModel = bloodStock
            .Select(bs => new BloodStockReportViewModel(            
                bloodType: bs.BloodType.ToString(),
                rHFactor: bs.RHFactor.ToString(),               
                quantityML: bs.QuantityML))
            .ToList();

        return bloodStockReportViewModel;
    }
}
