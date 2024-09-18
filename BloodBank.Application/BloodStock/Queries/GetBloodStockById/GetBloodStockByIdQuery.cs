using BloodBank.Application.BloodStock.ViewModels;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.BloodStock.Queries.GetBloodStockById;

public class GetBloodStockByIdQuery : IRequest<Result<BloodStockDetailsViewModel>>
{
    public GetBloodStockByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
