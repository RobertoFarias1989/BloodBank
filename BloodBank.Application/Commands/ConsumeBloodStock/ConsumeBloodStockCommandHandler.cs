using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Commands.ConsumeBloodStock;

public class ConsumeBloodStockCommandHandler : IRequestHandler<ConsumeBloodStockCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsumeBloodStockCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ConsumeBloodStockCommand request, CancellationToken cancellationToken)
    {
        var bloodStock = await _unitOfWork.BloodStockRepository.GetByIdAsync(request.Id);

        //checar se existe estoque para ser consumido referente aquela doação de sangue
        if (bloodStock is null)
            return Result.Fail(BloodStockErrors.NotFound);

        //se tiver você reduzi a quantidade até zero se passar disso eu emito um mensagem dizendo que o estoque máximo para aquela doação é a diferença
        

        if (bloodStock.IsActive == true)
        {
            
            var bloodStockResult =  bloodStock.ConsumeAmount(request.QuantityML);

            if(!bloodStockResult.Success)
                return Result.Fail(bloodStockResult.Errors);


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

