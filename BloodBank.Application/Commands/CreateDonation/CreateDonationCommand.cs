using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonation;

public class CreateDonationCommand : IRequest<Result<int>>
{
    public int QuantityML { get;  set; }
    public int IdDonor { get;  set; }
}
