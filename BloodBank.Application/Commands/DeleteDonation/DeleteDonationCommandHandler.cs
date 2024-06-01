using BloodBank.Application.Erros;
using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;
using System.Net;

namespace BloodBank.Application.Commands.DeleteDonation;

public class DeleteDonationCommandHandler : IRequestHandler<DeleteDonationCommand, Result>
{
    private readonly IDonationRepository _donationRepository;

    public DeleteDonationCommandHandler(IDonationRepository donationRepository)
    {
        _donationRepository = donationRepository;
    }

    public async Task<Result> Handle(DeleteDonationCommand request, CancellationToken cancellationToken)
    {
        var donation = await _donationRepository.GetByIdAsync(request.Id);

        if(donation is null)
            return Result.Fail(DonationErrors.NotFound);

        if(donation.IsActive == true)
        {
            donation.Inactive();

            await _donationRepository.UpdateAsync(donation);
        }
        else
        {
            return Result.Fail(DonationErrors.AlreadyInactived);
        }

        return Result.Ok();
    }
}
