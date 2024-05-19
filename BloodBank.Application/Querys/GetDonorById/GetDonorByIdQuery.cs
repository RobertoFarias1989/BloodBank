using BloodBank.Application.ViewModels;
using MediatR;

namespace BloodBank.Application.Querys.GetDonorById;

public class GetDonorByIdQuery : IRequest<DonorDetailsViewModel>
{
    public GetDonorByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
