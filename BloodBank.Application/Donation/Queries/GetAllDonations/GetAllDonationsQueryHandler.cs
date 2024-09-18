using BloodBank.Application.Donation.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Donation.Queries.GetAllDonations;

public class GetAllDonationsQueryHandler : IRequestHandler<GetAllDonationsQuery, List<DonationViewModel>>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetAllDonationsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<DonationViewModel>> Handle(GetAllDonationsQuery request, CancellationToken cancellationToken)
    {
        var donations = await _unitOfWork.DonationRepository.GetAllAsync();

        var donationViewModel = donations
            .Select(dt => new DonationViewModel(
                id: dt.Id,
                donationDate: dt.DonationDate,
                quantityML: dt.QuantityML,
                idDonor: dt.IdDonor
                )).ToList();

        return donationViewModel;
    }
}
