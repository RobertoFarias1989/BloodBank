using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DeleteBloodStock;

public class DeleteBloodStockCommandHandler : IRequestHandler<DeleteBloodStockCommand, Unit>
{
    private readonly IBloodStockRepository _bloodStockRepository;

    public DeleteBloodStockCommandHandler(IBloodStockRepository bloodStockRepository)
    {
        _bloodStockRepository = bloodStockRepository;
    }

    public async Task<Unit> Handle(DeleteBloodStockCommand request, CancellationToken cancellationToken)
    {
        var bloodStock = await _bloodStockRepository.GetByIdAsync(request.Id);

        if(bloodStock.IsActive == true)
        {
            bloodStock.Inactive();

            await _bloodStockRepository.UpdateAsync(bloodStock);
        }
        else
        {
            throw new Exception("BloodStock register is already inactived.");
        }

        return Unit.Value;
   
    }
}
