using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DeleteDonation;

public class DeleteDonationCommandHandler : IRequestHandler<DeleteDonationCommand, Unit>
{
    private readonly IDonationRepository _donationRepository;

    public DeleteDonationCommandHandler(IDonationRepository donationRepository)
    {
        _donationRepository = donationRepository;
    }

    public async Task<Unit> Handle(DeleteDonationCommand request, CancellationToken cancellationToken)
    {
        var donation = await _donationRepository.GetByIdAsync(request.Id);

        if(donation.IsActive == true)
        {
            donation.Inactive();

            await _donationRepository.UpdateAsync(donation);
        }
        else
        {
            throw new Exception("The donation is already inactived.");
        }

        return Unit.Value;
    }
}
