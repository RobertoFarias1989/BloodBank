using BloodBank.Application.Donor.ViewModels;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Donor.Queries.GetDonorById;

public class GetDonorByIdQuery : IRequest<Result<DonorDetailsViewModel>>
{
    public GetDonorByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
