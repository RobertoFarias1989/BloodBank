using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Querys.GetAllDonations
{
    public class GetAllDonationsQueryHandler : IRequestHandler<GetAllDonationsQuery, List<DonationViewModel>>
    {
        private readonly IDonationRepository _donationRepository;

        public GetAllDonationsQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public Task<List<DonationViewModel>> Handle(GetAllDonationsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
