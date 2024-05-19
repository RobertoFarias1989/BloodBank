using BloodBank.Application.ViewModels;
using BloodBank.Core.Enums;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Querys.GetBloodStockByIdQuery;

public class GetBloodStockByIdQueryHandler : IRequestHandler<GetBloodStockByIdQuery, BloodStockDetailsViewModel>
{
    private readonly IBloodStockRepository _bloodStockRepository;

    public GetBloodStockByIdQueryHandler(IBloodStockRepository bloodStockRepository)
    {
        _bloodStockRepository = bloodStockRepository;
    }

    public async Task<BloodStockDetailsViewModel> Handle(GetBloodStockByIdQuery request, CancellationToken cancellationToken)
    {
        var bloodStock = await _bloodStockRepository.GetDetailsById(request.Id);

        if (bloodStock == null) return null;

        var bloodStockDetailsViewModel = new BloodStockDetailsViewModel(
            id: bloodStock.Id,
            isActive: bloodStock.IsActive,
            createdAt: bloodStock.CreatedAt,
            updatedAt: bloodStock.UpdatedAt,
            bloodType: bloodStock.BloodType.ToString(),
            rHFactor: bloodStock.RHFactor.ToString(),
            quantityML: bloodStock.QuantityML);

        return bloodStockDetailsViewModel;
    }
}
