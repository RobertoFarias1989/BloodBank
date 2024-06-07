using BloodBank.Application.ViewModels;
using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Querys.GetDonorById;

public class GetDonorByIdQueryHandler : IRequestHandler<GetDonorByIdQuery, Result<DonorDetailsViewModel>>
{
   
    private readonly IUnitOfWork _unitOfWork;

    public GetDonorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<DonorDetailsViewModel>> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
    {
        var donor = await _unitOfWork.DonorRepository.GetDetailsByIdAsync(request.Id);

        if (donor == null)
            return Result.Fail<DonorDetailsViewModel>(DonorErrors.NotFound);

        var donations = donor.Donations
            .Where(dt => dt.IdDonor == donor.Id)
            .Select(dt => new DonationDetailsViewModel(
                id: dt.Id,
                isActive: dt.IsActive,
                createdAt: dt.CreatedAt,
                updatedAt: dt.UpdatedAt,
                donationDate: dt.DonationDate,
                quantityML: dt.QuantityML,
                idDonor: dt.IdDonor                
                )).ToList();

        var donorDetailsViewModel = new DonorDetailsViewModel(
            id: donor.Id,
            isActive: donor.IsActive,
            createdAt: donor.CreatedAt,
            updatedAt: donor.UpdatedAt,
            fullName: donor.Name.FullName,
            cPFNumber: donor.CPF.CPFNumber,
            emailAddress: donor.Email.EmailAddress,
            birthDate: donor.BirthDate,
            gender: donor.Gender.ToString(),
            weight: donor.Weight,
            bloodType: donor.BloodType.ToString(),
            rHFactor: donor.RHFactor.ToString(),
            street: donor.Address.Street,
            city: donor.Address.City,
            state: donor.Address.State,
            postalCode: donor.Address.PostalCode,
            country: donor.Address.Country,
            donations
            );

        return Result.Ok(donorDetailsViewModel);
    }
}
