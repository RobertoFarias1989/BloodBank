using BloodBank.Application.Donation.ViewModels;
using BloodBank.Core.Models;
using MediatR;

namespace BloodBank.Application.Donation.Queries.GetAllDonations;

public class GetAllDonationsQuery : IRequest<PaginationResult<DonationViewModel>>
{
    public GetAllDonationsQuery(int page)
    {
        Page = page;
    }

    public int Page { get; set; }
}
