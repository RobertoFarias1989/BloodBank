using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.UpdateDonation;

public class UpdateDonationCommandHandler : IRequestHandler<UpdateDonationCommand, Unit>
{
    private readonly IDonationRepository _donationRepository;

    public UpdateDonationCommandHandler(IDonationRepository donationRepository)
    {
        _donationRepository = donationRepository;
    }

    public async Task<Unit> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
    {
        var donation = await _donationRepository.GetByIdAsync(request.Id);

        donation.UpdateML(request.QuantityML);

        if (donation.QuantityML < 420 || donation.QuantityML > 470)
            throw new Exception("Number of milliliters of blood donated must be between 420ml and 470ml");

        await _donationRepository.UpdateAsync(donation);

        return Unit.Value;
    }
}
