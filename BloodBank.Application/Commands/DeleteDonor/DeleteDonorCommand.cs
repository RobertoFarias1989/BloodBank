using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Commands.DeleteDonor;

public class DeleteDonorCommand : IRequest<Result>
{
    public DeleteDonorCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
