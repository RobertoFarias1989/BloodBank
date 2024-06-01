using BloodBank.Core.Entities;
using BloodBank.Core.Enums;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Commands.CreateBloodStock;

public class CreateBloodStockCommandHandler : IRequestHandler<CreateBloodStockCommand, Result<int>>
{
    private readonly IBloodStockRepository _bloodStockRepository;

    public CreateBloodStockCommandHandler(IBloodStockRepository bloodStockRepository)
    {
        _bloodStockRepository = bloodStockRepository;
    }

    public async Task<Result<int>> Handle(CreateBloodStockCommand request, CancellationToken cancellationToken)
    {
        var bloodStock = new BloodStock(
            bloodType: (BloodTypeEnum)Enum.Parse(typeof(BloodTypeEnum), request.BloodType),
            factorRH: (RHFactorEnum)Enum.Parse(typeof(RHFactorEnum), request.RHFactor),
            quantityML: request.QuantityML,
            idDonation: request.IdDonation
            );

        await _bloodStockRepository.AddAsync(bloodStock);

        return Result.Ok(bloodStock.Id);
    }
}
