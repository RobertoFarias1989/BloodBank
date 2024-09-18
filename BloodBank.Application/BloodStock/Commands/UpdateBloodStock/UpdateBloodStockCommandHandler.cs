using BloodBank.Core.Enums;
using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.BloodStock.Commands.UpdateBloodStock;

public class UpdateBloodStockCommandHandler : IRequestHandler<UpdateBloodStockCommand, Result>
{

    private readonly IUnitOfWork _unitOfWork;

    public UpdateBloodStockCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateBloodStockCommand request, CancellationToken cancellationToken)
    {
        var bloodStock = await _unitOfWork.BloodStockRepository.GetByIdAsync(request.Id);

        if (bloodStock is null)
            return Result.Fail(BloodStockErrors.NotFound);

        bloodStock.Update(
            bloodType: (BloodTypeEnum)Enum.Parse(typeof(BloodTypeEnum), request.BloodType),
            factorRH: (RHFactorEnum)Enum.Parse(typeof(RHFactorEnum), request.RHFactor),
            quantityML: request.QuantityML
            );

        await _unitOfWork.BloodStockRepository.UpdateAsync(bloodStock);

        await _unitOfWork.CompletAsync();

        return Result.Ok();
    }
}
