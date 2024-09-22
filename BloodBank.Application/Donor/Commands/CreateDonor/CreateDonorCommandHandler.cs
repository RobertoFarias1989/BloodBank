using BloodBank.Core.Enums;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using BloodBank.Core.Services;
using BloodBank.Core.ValueObjects;
using MediatR;

namespace BloodBank.Application.Donor.Commands.CreateDonor;

public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, Result<int>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public CreateDonorCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<Result<int>> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.PasswordValue!);

        var donor = new Core.Entities.Donor(
            name: new Name(request.FullName!),
            cpf: new CPF(request.CPFNumber!),
            email: new Email(request.EmailAddress!),
            password: new Password(passwordHash),
            role: request.Role!,
            birthDate: request.BirthDate,
            gender: (GenderEnum)Enum.Parse(typeof(GenderEnum), request.Gender!),
            weight: request.Weight,
            bloodType: (BloodTypeEnum)Enum.Parse(typeof(BloodTypeEnum), request.BloodType!),
            rHFactor: (RHFactorEnum)Enum.Parse(typeof(RHFactorEnum), request.RHFactor!),
            address: new Address(request.Street!, request.City!, request.State!, request.PostalCode!, request.Country!)
            );

        await _unitOfWork.DonorRepository.AddAsync(donor);

        await _unitOfWork.CompletAsync();

        return Result.Ok(donor.Id);
    }
}
