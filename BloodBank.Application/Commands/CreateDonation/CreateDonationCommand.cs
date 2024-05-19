using MediatR;

namespace BloodBank.Application.Commands.CreateDonation;

public class CreateDonationCommand : IRequest<int>
{
    public int QuantityML { get;  set; }
    public int IdDonor { get;  set; }
}
