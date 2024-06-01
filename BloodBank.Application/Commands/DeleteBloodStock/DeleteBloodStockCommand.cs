using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Commands.DeleteBloodStock;

public class DeleteBloodStockCommand : IRequest<Result>
{
    public DeleteBloodStockCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
