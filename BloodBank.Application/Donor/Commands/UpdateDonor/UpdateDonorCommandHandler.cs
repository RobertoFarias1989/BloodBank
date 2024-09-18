using BloodBank.Core.Enums;
using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using BloodBank.Core.ValueObjects;
using MediatR;

namespace BloodBank.Application.Donor.Commands.UpdateDonor;

public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, Result>
{

    private readonly IUnitOfWork _unitOfWork;

    public UpdateDonorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
    {
        var donor = await _unitOfWork.DonorRepository.GetByIdAsync(request.Id);

        if (donor is null)
            return Result.Fail(DonorErrors.NotFound);

        donor.Update(
            name: new Name(request.FullName),
            cpf: new CPF(request.CPFNumber),
            email: new Email(request.EmailAddress),
            birthDate: request.BirthDate,
            gender: (GenderEnum)Enum.Parse(typeof(GenderEnum), request.Gender),
            weight: request.Weight,
            bloodType: (BloodTypeEnum)Enum.Parse(typeof(BloodTypeEnum), request.BloodType),
            rHFactor: (RHFactorEnum)Enum.Parse(typeof(RHFactorEnum), request.RHFactor),
            address: new Address(request.Street, request.City, request.Street, request.PostalCode, request.Country)
            );

        await _unitOfWork.DonorRepository.UpdateAsync(donor);

        await _unitOfWork.CompletAsync();

        return Result.Ok();
    }
}
