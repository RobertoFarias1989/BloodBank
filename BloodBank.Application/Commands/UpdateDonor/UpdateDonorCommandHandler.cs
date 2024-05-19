using BloodBank.Core.Enums;
using BloodBank.Core.Repositories;
using BloodBank.Core.ValueObjects;
using MediatR;

namespace BloodBank.Application.Commands.UpdateDonor;

public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, Unit>
{
    private readonly IDonorRepository _donorRepository;

    public UpdateDonorCommandHandler(IDonorRepository donorRepository)
    {
        _donorRepository = donorRepository;
    }

    public async Task<Unit> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
    {
        var donor = await _donorRepository.GetByIdAsync(request.Id);

        donor.Update(
            name: new Name(request.FullName),
            cpf: new CPF(request.CPFNumber),
            email: new Email(request.EmailAddress),
            birthDate: request.BirthDate,
            gender: (GenderEnum)Enum.Parse(typeof(GenderEnum), request.Gender),
            weight: request.Weight,
            bloodType: (BloodTypeEnum)Enum.Parse(typeof(BloodTypeEnum), request.BloodType),
            rHFactor: (RHFactorEnum)Enum.Parse(typeof(RHFactorEnum), request.RHFactor),
            address: new Address(request.Street,request.City, request.Street,request.PostalCode, request.Country)
            );

        await _donorRepository.UpdateAsync(donor);

        return Unit.Value;
    }
}
