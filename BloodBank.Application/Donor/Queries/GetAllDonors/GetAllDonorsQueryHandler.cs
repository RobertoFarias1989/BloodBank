using BloodBank.Application.Donor.ViewModels;
using BloodBank.Core.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Donor.Queries.GetAllDonors;

public class GetAllDonorsQueryHandler : IRequestHandler<GetAllDonorsQuery, PaginationResult<DonorViewModel>>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetAllDonorsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PaginationResult<DonorViewModel>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
    {
        var paginationDonors = await _unitOfWork.DonorRepository.GetAllAsync(request.Query, request.Page);

        var donorViewModel = paginationDonors
            .Data
            .Select(d => new DonorViewModel(
                d.Id,
                d.Name.FullName,
                d.BirthDate,
                d.Gender.ToString(),
                d.Weight,
                d.BloodType.ToString(),
                d.RHFactor.ToString()))
            .ToList();

        var paginationDonorsViewModel = new PaginationResult<DonorViewModel>(
            paginationDonors.Page,
                paginationDonors.TotalPages,
                paginationDonors.PageSize,
                paginationDonors.ItemsCount,
                donorViewModel);

        return paginationDonorsViewModel;
    }
}
