using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Donation.Commands.DeleteDonation;

public class DeleteDonationCommandHandler : IRequestHandler<DeleteDonationCommand, Result>
{

    private readonly IUnitOfWork _unitOfWork;

    public DeleteDonationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteDonationCommand request, CancellationToken cancellationToken)
    {
        var donation = await _unitOfWork.DonorRepository.GetByIdAsync(request.Id);

        if (donation is null)
            return Result.Fail(DonationErrors.NotFound);

        if (donation.IsActive == true)
        {
            donation.Inactive();

            await _unitOfWork.DonorRepository.UpdateAsync(donation);

            await _unitOfWork.CompletAsync();
        }
        else
        {
            return Result.Fail(DonationErrors.AlreadyInactived);
        }

        return Result.Ok();
    }
}
