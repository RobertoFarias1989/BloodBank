using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonation;

public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, int>
{
    private readonly IDonationRepository _donationRepository;
    private readonly IDonorRepository _donorRepository;

    public CreateDonationCommandHandler(IDonationRepository donationRepository, IDonorRepository donorRepository)
    {
        _donationRepository = donationRepository;
        _donorRepository = donorRepository;
    }

    public async Task<int> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
    {
        var donor = await _donorRepository.GetDetailsByIdAsync(request.IdDonor);        

        //Menor de idade não pode doar, mas pode ter cadastro.
        var today = DateTime.Today;

        var age = today.Year - donor.BirthDate.Year;

        if (age < 16 && age > 69)
            throw new Exception("You must have age between 16 and 69.");

        //Pesar no mínimo 50KG.
        if (donor.Weight < 50)
            throw new Exception("You must have more than 50kg.");

        //Mulheres só podem doar de 90 em 90 dias.(PLUS)
        if(donor.Gender == Core.Enums.GenderEnum.Female && donor.Donations != null)
        {
            var lastDonation = donor.Donations.OrderByDescending(dt => dt.Id).Select(dt => dt.DonationDate).First();

            var diferrence = today - lastDonation;

            var days = diferrence.Days;

            if (days < 90)
                throw new Exception("Women can only donate every 90 days.");
        }

        //Homens só podem doar de 60 em 60 dias.
        if (donor.Gender == Core.Enums.GenderEnum.Male && donor.Donations != null)
        {
            var lastDonation = donor.Donations.OrderByDescending(dt => dt.Id).Select(dt => dt.DonationDate).First();

            var diferrence = today - lastDonation;

            var days = diferrence.Days;

            if (days < 60)
                throw new Exception("Men can only donate every 60 days.");
        }

        //Quantidade de mililitros de sangue doados deve ser entre 420ml e 470ml
        if (request.QuantityML < 420 || request.QuantityML > 470)
            throw new Exception("Number of milliliters of blood donated must be between 420ml and 470ml");

        var donationEntity = new Donation(
            quantityML: request.QuantityML,
            idDonor: request.IdDonor
            );

        await _donationRepository.AddAsync(donationEntity);

        //TODO: criar ou atualizar BloodStock depois da doação

        return donationEntity.Id;

    }
}
