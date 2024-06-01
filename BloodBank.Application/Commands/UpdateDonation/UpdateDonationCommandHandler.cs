using BloodBank.Application.Erros;
using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;
using System.Net;

namespace BloodBank.Application.Commands.UpdateDonation;

public class UpdateDonationCommandHandler : IRequestHandler<UpdateDonationCommand, Result>
{
    private readonly IDonationRepository _donationRepository;
    private readonly IBloodStockRepository _bloodStockRepository;
    private readonly IDonorRepository _donorRepository;

    public UpdateDonationCommandHandler(IDonationRepository donationRepository, IBloodStockRepository bloodStockRepository, IDonorRepository donorRepository)
    {
        _donationRepository = donationRepository;
        _bloodStockRepository = bloodStockRepository;
        _donorRepository = donorRepository;
    }

    public async Task<Result> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
    {
        var donation = await _donationRepository.GetByIdAsync(request.Id);

        if (donation is null)
            return Result.Fail(DonationErrors.NotFound);

        if (!donation.IsActive)
            return Result.Fail(DonationErrors.AlreadyInactived);

        var donationResult =  donation.AmountMillimeterToDonate(request.QuantityML);

        if (!donationResult.Success)
            return Result.Fail(donationResult.Errors);

        donation.UpdateML(request.QuantityML);        

        await _donationRepository.UpdateAsync(donation);

        var bloodStook = await _bloodStockRepository.GetByIdAsync(donation.Id);

        if (bloodStook is null)
            return Result.Fail(new HttpStatusCodeError(BloodStockErrors.NotFound, HttpStatusCode.NotFound));

        bloodStook.UpdateAmount(donation.QuantityML);

        await _bloodStockRepository.UpdateAsync(bloodStook);

        return Result.Ok();
    }
}
