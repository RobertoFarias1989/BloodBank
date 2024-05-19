using BloodBank.Core.Enums;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.UpdateBloodStock;

public class UpdateBloodStockCommandHandler : IRequestHandler<UpdateBloodStockCommand, Unit>
{
    private readonly IBloodStockRepository _bloodStockRepository;

    public UpdateBloodStockCommandHandler(IBloodStockRepository bloodStockRepository)
    {
        _bloodStockRepository = bloodStockRepository;
    }

    public async Task<Unit> Handle(UpdateBloodStockCommand request, CancellationToken cancellationToken)
    {
        var bloodStock = await _bloodStockRepository.GetByIdAsync(request.Id);       

        bloodStock.Update(
            bloodType: (BloodTypeEnum)Enum.Parse(typeof(BloodTypeEnum), request.BloodType),
            factorRH: (RHFactorEnum)Enum.Parse(typeof(RHFactorEnum), request.RHFactor),
            quantityML: request.QuantityML
            );

        await _bloodStockRepository.UpdateAsync(bloodStock);

        return Unit.Value;
    }
}
