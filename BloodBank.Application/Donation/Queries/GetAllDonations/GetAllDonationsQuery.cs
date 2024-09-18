using BloodBank.Application.Donation.ViewModels;
using MediatR;

namespace BloodBank.Application.Donation.Queries.GetAllDonations;

public class GetAllDonationsQuery : IRequest<List<DonationViewModel>>
{
    public GetAllDonationsQuery(string query)
    {
        Query = query;
    }

    public string Query { get; private set; }
}
