using BloodBank.Application.Donation.ViewModels;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Donation.Queries.GetDonationById;

public class GetDonationByIdQuery : IRequest<Result<DonationDetailsViewModel>>
{
    public GetDonationByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
