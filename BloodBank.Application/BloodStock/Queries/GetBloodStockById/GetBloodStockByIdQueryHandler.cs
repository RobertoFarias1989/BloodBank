using BloodBank.Application.BloodStock.ViewModels;
using BloodBank.Core.Enums;
using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.BloodStock.Queries.GetBloodStockById;

public class GetBloodStockByIdQueryHandler : IRequestHandler<GetBloodStockByIdQuery, Result<BloodStockDetailsViewModel>>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetBloodStockByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<BloodStockDetailsViewModel>> Handle(GetBloodStockByIdQuery request, CancellationToken cancellationToken)
    {
        var bloodStock = await _unitOfWork.BloodStockRepository.GetDetailsById(request.Id);

        if (bloodStock == null)
            return Result.Fail<BloodStockDetailsViewModel>(BloodStockErrors.NotFound);

        var bloodStockDetailsViewModel = new BloodStockDetailsViewModel(
            id: bloodStock.Id,
            isActive: bloodStock.IsActive,
            createdAt: bloodStock.CreatedAt,
            updatedAt: bloodStock.UpdatedAt,
            bloodType: bloodStock.BloodType.ToString(),
            rHFactor: bloodStock.RHFactor.ToString(),
            quantityML: bloodStock.QuantityML,
            validateUntil: bloodStock.ValidateUntil,
            idDonation: bloodStock.IdDonation);

        return Result.Ok(bloodStockDetailsViewModel);
    }
}
