using BloodBank.Application.BloodStock.ViewModels;
using BloodBank.Core.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.BloodStock.Queries.GetAllBloodStocks;

public class GetAllBloodStocksQueryHandler : IRequestHandler<GetAllBloodStocksQuery, PaginationResult<BloodStockViewModel>>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetAllBloodStocksQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PaginationResult<BloodStockViewModel>> Handle(GetAllBloodStocksQuery request, CancellationToken cancellationToken)
    {
        var paginationBloodStock = await _unitOfWork.BloodStockRepository.GetAllAsync(request.Query, request.Page);

        var bloodStockViewModel = paginationBloodStock
            .Data
            .Select(bs => new BloodStockViewModel(
                id: bs.Id,
                bloodType: bs.BloodType.ToString(),
                rHFactor: bs.RHFactor.ToString(),
                validateUntil: bs.ValidateUntil.ToShortDateString(),
                idDonation: bs.IdDonation))
            .ToList();

        var paginationBloodStockViewModel = new PaginationResult<BloodStockViewModel>(
                paginationBloodStock.Page,
                paginationBloodStock.TotalPages,
                paginationBloodStock.PageSize,
                paginationBloodStock.ItemsCount,
                bloodStockViewModel);

        return paginationBloodStockViewModel;
    }
}
