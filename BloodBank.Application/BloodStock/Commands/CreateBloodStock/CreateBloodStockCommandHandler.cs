using BloodBank.Core.Enums;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.BloodStock.Commands.CreateBloodStock;

public class CreateBloodStockCommandHandler : IRequestHandler<CreateBloodStockCommand, Result<int>>
{

    private readonly IUnitOfWork _unitOfWork;

    public CreateBloodStockCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateBloodStockCommand request, CancellationToken cancellationToken)
    {
        var bloodStock = new Core.Entities.BloodStock(
            bloodType: (BloodTypeEnum)Enum.Parse(typeof(BloodTypeEnum), request.BloodType),
            factorRH: (RHFactorEnum)Enum.Parse(typeof(RHFactorEnum), request.RHFactor),
            quantityML: request.QuantityML,
            idDonation: request.IdDonation
            );

        await _unitOfWork.BloodStockRepository.AddAsync(bloodStock);

        await _unitOfWork.CompletAsync();

        return Result.Ok(bloodStock.Id);
    }
}
