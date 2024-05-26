using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DeleteDonor;

public class DeleteDonorCommandHandler : IRequestHandler<DeleteDonorCommand, Unit>
{
    private readonly IDonorRepository _donorRepository;

    public DeleteDonorCommandHandler(IDonorRepository donorRepository)
    {
        _donorRepository = donorRepository;
    }

    public async Task<Unit> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
    {
        var donor = await _donorRepository.GetByIdAsync(request.Id);

        if(donor.IsActive == true)
        {
            donor.Inactive();

            await _donorRepository.UpdateAsync(donor);
        }
        else
        {
            throw new Exception("The donor is already inactived.");
        }

        return Unit.Value;
    }
}
