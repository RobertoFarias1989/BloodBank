using BloodBank.Application.ViewModels;
using MediatR;

namespace BloodBank.Application.Querys.GetDonationById;

public class GetDonationByIdQuery : IRequest<DonationDetailsViewModel>
{
    public GetDonationByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
