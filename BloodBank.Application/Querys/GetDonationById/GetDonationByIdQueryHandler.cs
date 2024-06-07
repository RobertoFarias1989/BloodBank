using BloodBank.Application.ViewModels;
using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Querys.GetDonationById;

public class GetDonationByIdQueryHandler : IRequestHandler<GetDonationByIdQuery, Result<DonationDetailsViewModel>>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetDonationByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<DonationDetailsViewModel>> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
    {
        var donation = await _unitOfWork.DonationRepository.GetByIdAsync(request.Id);

        if (donation == null)
            return Result.Fail<DonationDetailsViewModel>(DonationErrors.NotFound);

        var donationDetailsViewModel = new DonationDetailsViewModel(
            id: donation.Id,
            isActive: donation.IsActive,
            createdAt: donation.CreatedAt,
            updatedAt: donation.UpdatedAt,
            donationDate: donation.DonationDate,
            quantityML: donation.QuantityML,
            idDonor: donation.IdDonor);

        return Result.Ok(donationDetailsViewModel);
    }
}
