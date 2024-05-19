using MediatR;

namespace BloodBank.Application.Commands.DeleteBloodStock;

public class DeleteBloodStockCommand : IRequest<Unit>
{
    public DeleteBloodStockCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
