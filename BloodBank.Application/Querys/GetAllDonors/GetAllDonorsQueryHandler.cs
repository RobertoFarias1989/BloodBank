﻿using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Querys.GetAllDonors;

public class GetAllDonorsQueryHandler : IRequestHandler<GetAllDonorsQuery, List<DonorViewModel>>
{
   
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDonorsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<DonorViewModel>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
    {
        var donor = await _unitOfWork.DonorRepository.GetAllAsync();

        var donorViewModel = donor
            .Select(d => new DonorViewModel(
                d.Id, 
                d.Name.FullName, 
                d.BirthDate, 
                d.Gender.ToString(),
                d.Weight, 
                d.BloodType.ToString(), 
                d.RHFactor.ToString()))
            .ToList();

        return donorViewModel;
    }
}
