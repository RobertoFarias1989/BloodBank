using MediatR;

namespace BloodBank.Application.Commands.UpdateDonation;

public class UpdateDonationCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int QuantityML { get; set; }
}
