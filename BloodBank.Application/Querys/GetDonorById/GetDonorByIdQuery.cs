using BloodBank.Application.ViewModels;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Querys.GetDonorById;

public class GetDonorByIdQuery : IRequest<Result<DonorDetailsViewModel>>
{
    public GetDonorByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
