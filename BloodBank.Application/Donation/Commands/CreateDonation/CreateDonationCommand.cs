using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Donation.Commands.CreateDonation;

public class CreateDonationCommand : IRequest<Result<int>>
{
    public int QuantityML { get; set; }
    public int IdDonor { get; set; }
}
