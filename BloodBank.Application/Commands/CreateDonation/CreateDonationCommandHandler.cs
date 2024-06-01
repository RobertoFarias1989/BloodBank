﻿using BloodBank.Application.Erros;
using BloodBank.Core.Entities;
using BloodBank.Core.Erros;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;
using System.Net;

namespace BloodBank.Application.Commands.CreateDonation;

public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, Result<int>>
{
    private readonly IDonationRepository _donationRepository;
    private readonly IDonorRepository _donorRepository;
    private readonly IBloodStockRepository _bloodStockRepository;

    public CreateDonationCommandHandler(IDonationRepository donationRepository, IDonorRepository donorRepository, IBloodStockRepository bloodStockRepository)
    {
        _donationRepository = donationRepository;
        _donorRepository = donorRepository;
        _bloodStockRepository = bloodStockRepository;
    }

    public async Task<Result<int>> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
    {
        var donor = await _donorRepository.GetDetailsByIdAsync(request.IdDonor);

        if (donor is null)           
            return Result.Fail<int>(DonorErrors.NotFound);

        if (!donor.IsActive)
            return Result.Fail<int>(DonorErrors.AlreadyInactived);


        //faça a validação de todas as regras de negócios relacionadas ao Donor:
        //Menor de idade não pode doar, mas pode ter cadastro.
        //Pesar no mínimo 50KG.
        //Mulheres só podem doar de 90 em 90 dias.(PLUS)
        //Homens só podem doar de 60 em 60 dias.
        var donorResult =  donor.AmIAbleToGiveBlood(donor);

        if (!donorResult.Success)
        {
            return Result.Fail<int>(donorResult.Errors);
        }

        //Monto o objeto Donation
        var donationEntity = new Donation(
            quantityML: request.QuantityML,
            idDonor: request.IdDonor
            );

        //Quantidade de mililitros de sangue doados deve ser entre 420ml e 470ml
        var donationResult =  donationEntity.AmountMillimeterToDonate(request.QuantityML);

        if (!donationResult.Success)
        {
            return Result.Fail<int>(donationResult.Errors);
        }

        //adiciono a doação
        await _donationRepository.AddAsync(donationEntity);

        var bloodStockEntity = new BloodStock(
            donor.BloodType,
            donor.RHFactor,
            donationEntity.QuantityML,
            donationEntity.Id
            );

        await _bloodStockRepository.AddAsync(bloodStockEntity);

        return Result.Ok(donationEntity.Id);

    }
}
