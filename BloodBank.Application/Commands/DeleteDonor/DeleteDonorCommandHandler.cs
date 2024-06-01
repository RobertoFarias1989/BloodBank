using BloodBank.Application.Erros;
using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;
using System.Net;

namespace BloodBank.Application.Commands.DeleteDonor;

public class DeleteDonorCommandHandler : IRequestHandler<DeleteDonorCommand, Result>
{
    private readonly IDonorRepository _donorRepository;

    public DeleteDonorCommandHandler(IDonorRepository donorRepository)
    {
        _donorRepository = donorRepository;
    }

    public async Task<Result> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
    {
        var donor = await _donorRepository.GetByIdAsync(request.Id);

        if (donor is null)
            return Result.Fail(new HttpStatusCodeError(DonorErrors.NotFound, HttpStatusCode.NotFound));

        if(donor.IsActive == true)
        {
            donor.Inactive();

            await _donorRepository.UpdateAsync(donor);
        }
        else
        {
            //throw new Exception("The donor is already inactived.");

            return Result.Fail(DonorErrors.AlreadyInactived);
        }

        return Result.Ok();
    }
}
