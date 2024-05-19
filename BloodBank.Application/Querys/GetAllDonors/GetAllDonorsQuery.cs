using BloodBank.Application.ViewModels;
using MediatR;

namespace BloodBank.Application.Querys.GetAllDonors;

public class GetAllDonorsQuery : IRequest<List<DonorViewModel>>
{
    public GetAllDonorsQuery(string query)
    {
        Query = query;
    }

    public string Query { get; private set; }
}
