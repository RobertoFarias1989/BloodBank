using BloodBank.Application.Donation.ViewModels;
using BloodBank.Core.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Donation.Queries.GetAllDonations;

public class GetAllDonationsQueryHandler : IRequestHandler<GetAllDonationsQuery, PaginationResult<DonationViewModel>>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetAllDonationsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PaginationResult<DonationViewModel>> Handle(GetAllDonationsQuery request, CancellationToken cancellationToken)
    {
        var paginationDonations = await _unitOfWork.DonationRepository.GetAllAsync(request.Page);

        var donationViewModel = paginationDonations
            .Data
            .Select(dt => new DonationViewModel(
                id: dt.Id,
                donationDate: dt.DonationDate,
                quantityML: dt.QuantityML,
                idDonor: dt.IdDonor
                )).ToList();

        var paginationDonationViewModel = new PaginationResult<DonationViewModel>(
             paginationDonations.Page,
                paginationDonations.TotalPages,
                paginationDonations.PageSize,
                paginationDonations.ItemsCount,
                donationViewModel);

        return paginationDonationViewModel;
    }
}
