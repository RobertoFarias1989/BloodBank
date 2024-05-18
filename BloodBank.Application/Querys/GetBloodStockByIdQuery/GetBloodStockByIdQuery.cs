using BloodBank.Application.ViewModels;
using MediatR;

namespace BloodBank.Application.Querys.GetBloodStockByIdQuery
{
    public class GetBloodStockByIdQuery : IRequest<BloodStockDetailsViewModel>
    {
        public GetBloodStockByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
