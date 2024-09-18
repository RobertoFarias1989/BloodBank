using BloodBank.Application.Donor.ViewModels;
using MediatR;

namespace BloodBank.Application.Donor.Queries.GetAllDonors;

public class GetAllDonorsQuery : IRequest<List<DonorViewModel>>
{
    public GetAllDonorsQuery(string query)
    {
        Query = query;
    }

    public string Query { get; private set; }
}
