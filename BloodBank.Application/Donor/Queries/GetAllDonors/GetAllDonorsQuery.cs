using BloodBank.Application.Donor.ViewModels;
using BloodBank.Core.Models;
using MediatR;

namespace BloodBank.Application.Donor.Queries.GetAllDonors;

public class GetAllDonorsQuery : IRequest<PaginationResult<DonorViewModel>>
{
    public GetAllDonorsQuery(string query, int page)
    {
        Query = query;
        Page = page;
    }

    public string Query { get;  set; }
    public int Page { get; set; }
}
