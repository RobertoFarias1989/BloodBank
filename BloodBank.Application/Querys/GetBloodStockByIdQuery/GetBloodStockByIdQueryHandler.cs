using BloodBank.Application.ViewModels;
using BloodBank.Core.Enums;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Querys.GetBloodStockByIdQuery
{
    public class GetBloodStockByIdQueryHandler : IRequestHandler<GetBloodStockByIdQuery, BloodStockDetailsViewModel>
    {
        private readonly IBloodStockRepository _bloodStockRepository;

        public GetBloodStockByIdQueryHandler(IBloodStockRepository bloodStockRepository)
        {
            _bloodStockRepository = bloodStockRepository;
        }

        public async Task<BloodStockDetailsViewModel> Handle(GetBloodStockByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _bloodStockRepository.GetDetailsById(request.Id);

            if (entity == null) return null;

            var model = new BloodStockDetailsViewModel(
                entity.Id,
                entity.IsActive,
                entity.CreatedAt,
                entity.UpdatedAt,
                Enum.GetName(typeof(BloodTypeEnum), entity.BloodType),
                Enum.GetName(typeof(RHFactorEnum), entity.RHFactor),
                entity.QuantityML);

            return model;
        }
    }
}
