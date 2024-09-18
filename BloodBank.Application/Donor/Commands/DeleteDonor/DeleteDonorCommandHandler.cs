using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Donor.Commands.DeleteDonor;

public class DeleteDonorCommandHandler : IRequestHandler<DeleteDonorCommand, Result>
{

    private readonly IUnitOfWork _unitOfWork;

    public DeleteDonorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
    {
        var donor = await _unitOfWork.DonorRepository.GetByIdAsync(request.Id);

        if (donor is null)
            return Result.Fail(DonorErrors.NotFound);

        if (donor.IsActive == true)
        {
            donor.Inactive();

            await _unitOfWork.DonorRepository.UpdateAsync(donor);

            await _unitOfWork.CompletAsync();
        }
        else
        {

            return Result.Fail(DonorErrors.AlreadyInactived);
        }

        return Result.Ok();
    }
}
