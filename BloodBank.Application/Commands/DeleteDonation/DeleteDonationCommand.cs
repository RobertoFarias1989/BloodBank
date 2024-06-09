using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Commands.DeleteDonation;

public class DeleteDonationCommand : IRequest<Result>
{
    public DeleteDonationCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
