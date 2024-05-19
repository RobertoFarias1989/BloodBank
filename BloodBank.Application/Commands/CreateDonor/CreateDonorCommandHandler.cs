using BloodBank.Core.Entities;
using BloodBank.Core.Enums;
using BloodBank.Core.Repositories;
using BloodBank.Core.ValueObjects;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonor;

public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, int>
{
    private readonly IDonorRepository _donorRepository;

    public CreateDonorCommandHandler(IDonorRepository donorRepository)
    {
        _donorRepository = donorRepository;
    }

    public async Task<int> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
    {
        var donor = new Donor(
            name:new Name( request.FullName),
            cpf: new CPF(request.CPFNumber),
            email: new Email(request.EmailAddress),
            birthDate: request.BirthDate,
            gender: (GenderEnum)Enum.Parse(typeof(GenderEnum),request.Gender),
            weight: request.Weight,
            bloodType: (BloodTypeEnum)Enum.Parse(typeof(BloodTypeEnum),request.BloodType),
            rHFactor: (RHFactorEnum)Enum.Parse(typeof(RHFactorEnum),request.RHFactor),
            address: new Address(request.Street,request.City,request.State,request.PostalCode,request.Country)
            );

        await _donorRepository.AddAsync(donor);

        return donor.Id;
    }
}
