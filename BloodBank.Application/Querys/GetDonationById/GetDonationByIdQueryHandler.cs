using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Querys.GetDonationById;

public class GetDonationByIdQueryHandler : IRequestHandler<GetDonationByIdQuery, DonationDetailsViewModel>
{
    private readonly IDonationRepository _donationRepository;

    public GetDonationByIdQueryHandler(IDonationRepository donationRepository)
    {
        _donationRepository = donationRepository;
    }

    public async Task<DonationDetailsViewModel> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
    {
        var donation = await _donationRepository.GetByIdAsync(request.Id);

        if (donation == null) return null;

        var donationDetailsViewModel = new DonationDetailsViewModel(
            id: donation.Id,
            isActive: donation.IsActive,
            createdAt: donation.CreatedAt,
            updatedAt: donation.UpdatedAt,
            donationDate: donation.DonationDate,
            quantityML: donation.QuantityML,
            idDonor: donation.IdDonor);

        return donationDetailsViewModel;
    }
}
