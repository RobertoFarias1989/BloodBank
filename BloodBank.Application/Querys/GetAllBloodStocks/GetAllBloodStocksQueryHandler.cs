using BloodBank.Application.ViewModels;
using BloodBank.Core.Enums;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Querys.GetAllBloodStocks
{
    public class GetAllBloodStocksQueryHandler : IRequestHandler<GetAllBloodStocksQuery, List<BloodStockViewModel>>
    {
        private readonly IBloodStockRepository _bloodStockRepository;
        public async Task<List<BloodStockViewModel>> Handle(GetAllBloodStocksQuery request, CancellationToken cancellationToken)
        {
            var entity = await _bloodStockRepository.GetAllAsync();

            var viewModel = entity
                .Select(e=> new BloodStockViewModel(e.Id,
                Enum.GetName(typeof(BloodTypeEnum),e.BloodType),
                Enum.GetName(typeof(RHFactorEnum),e.RHFactor)
                )).ToList();

            return viewModel;
        }
    }
}
