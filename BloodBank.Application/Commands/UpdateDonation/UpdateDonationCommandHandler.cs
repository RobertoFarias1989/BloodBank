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
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDonationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
    {
        var donation = await _unitOfWork.DonationRepository.GetByIdAsync(request.Id);

        if (donation is null)
            return Result.Fail(DonationErrors.NotFound);

        if (!donation.IsActive)
            return Result.Fail(DonationErrors.AlreadyInactived);

        var donationResult =  donation.AmountMillimeterToDonate(request.QuantityML);

        if (!donationResult.Success)
            return Result.Fail(donationResult.Errors);

        donation.UpdateML(request.QuantityML);        

        await _unitOfWork.DonationRepository.UpdateAsync(donation);

        await _unitOfWork.CompletAsync();

        var bloodStook = await _unitOfWork.BloodStockRepository.GetByIdAsync(donation.Id);

        if (bloodStook is null)
            return Result.Fail(new HttpStatusCodeError(BloodStockErrors.NotFound, HttpStatusCode.NotFound));

        bloodStook.UpdateAmount(donation.QuantityML);

        await _unitOfWork.BloodStockRepository.UpdateAsync(bloodStook);

        await _unitOfWork.CompletAsync();

        return Result.Ok();
    }
}
