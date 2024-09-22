using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.BloodStock.Commands.DeleteBloodStock;

public class DeleteBloodStockCommandHandler : IRequestHandler<DeleteBloodStockCommand, Result>
{

    private readonly IUnitOfWork _unitOfWork;

    public DeleteBloodStockCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteBloodStockCommand request, CancellationToken cancellationToken)
    {
        var bloodStock = await _unitOfWork.BloodStockRepository.GetByIdAsync(request.Id);

        //if (bloodStock is null)
        //    return Result.Fail(BloodStockErrors.NotFound);

        if (bloodStock.IsActive == true)
        {
            bloodStock.Inactive();

            await _unitOfWork.BloodStockRepository.UpdateAsync(bloodStock);

            await _unitOfWork.CompletAsync();
        }
        else
        {

            return Result.Fail(BloodStockErrors.AlreadyInactived);
        }

        return Result.Ok();

    }
}
