using BloodBank.Application.ViewModels;
using MediatR;

namespace BloodBank.Application.Querys.GetAllDonations
{
    public class GetAllDonationsQuery : IRequest<List<DonationViewModel>>
    {
        public string Query { get; private set; }
    }
}
