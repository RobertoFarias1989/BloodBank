using MediatR;

namespace BloodBank.Application.Commands.DeleteDonation;

public class DeleteDonationCommand : IRequest<Unit>
{
    public DeleteDonationCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
