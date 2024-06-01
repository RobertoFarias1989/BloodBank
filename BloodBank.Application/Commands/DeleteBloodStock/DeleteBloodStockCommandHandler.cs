using BloodBank.Application.Erros;
using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;
using System.Net;

namespace BloodBank.Application.Commands.DeleteBloodStock;

public class DeleteBloodStockCommandHandler : IRequestHandler<DeleteBloodStockCommand, Result>
{
    private readonly IBloodStockRepository _bloodStockRepository;

    public DeleteBloodStockCommandHandler(IBloodStockRepository bloodStockRepository)
    {
        _bloodStockRepository = bloodStockRepository;
    }

    public async Task<Result> Handle(DeleteBloodStockCommand request, CancellationToken cancellationToken)
    {
        var bloodStock = await _bloodStockRepository.GetByIdAsync(request.Id);

        if (bloodStock is null)
            return Result.Fail(new HttpStatusCodeError(BloodStockErrors.NotFound, HttpStatusCode.NotFound));

        if (bloodStock.IsActive == true)
        {
            bloodStock.Inactive();

            await _bloodStockRepository.UpdateAsync(bloodStock);
        }
        else
        {
            //throw new Exception("BloodStock register is already inactived.");

            //return Result.Fail(new HttpStatusCodeError(BloodStockErrors.AlreadyInactived, HttpStatusCode.BadRequest));

            return Result.Fail(BloodStockErrors.AlreadyInactived);
        }

        return Result.Ok();
   
    }
}
