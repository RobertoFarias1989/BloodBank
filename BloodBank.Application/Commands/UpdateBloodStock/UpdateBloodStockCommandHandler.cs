using BloodBank.Application.Erros;
using BloodBank.Core.Enums;
using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;
using System.Net;

namespace BloodBank.Application.Commands.UpdateBloodStock;

public class UpdateBloodStockCommandHandler : IRequestHandler<UpdateBloodStockCommand, Result>
{
    private readonly IBloodStockRepository _bloodStockRepository;

    public UpdateBloodStockCommandHandler(IBloodStockRepository bloodStockRepository)
    {
        _bloodStockRepository = bloodStockRepository;
    }

    public async Task<Result> Handle(UpdateBloodStockCommand request, CancellationToken cancellationToken)
    {
        var bloodStock = await _bloodStockRepository.GetByIdAsync(request.Id);

        if (bloodStock is null)
            return Result.Fail(new HttpStatusCodeError(BloodStockErrors.NotFound, HttpStatusCode.NotFound));

        bloodStock.Update(
            bloodType: (BloodTypeEnum)Enum.Parse(typeof(BloodTypeEnum), request.BloodType),
            factorRH: (RHFactorEnum)Enum.Parse(typeof(RHFactorEnum), request.RHFactor),
            quantityML: request.QuantityML
            );

        await _bloodStockRepository.UpdateAsync(bloodStock);

        return Result.Ok();
    }
}
