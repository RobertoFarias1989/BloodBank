using BloodBank.Application.ViewModels;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Querys.GetBloodStockByIdQuery;

public class GetBloodStockByIdQuery : IRequest<Result<BloodStockDetailsViewModel>>
{
    public GetBloodStockByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
