using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Donation.Commands.UpdateDonation;

public class UpdateDonationCommand : IRequest<Result>
{
    public int Id { get; set; }
    public int QuantityML { get; set; }
}
