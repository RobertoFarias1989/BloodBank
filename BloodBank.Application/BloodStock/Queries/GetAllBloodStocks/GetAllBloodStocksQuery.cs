using BloodBank.Application.BloodStock.ViewModels;
using MediatR;

namespace BloodBank.Application.BloodStock.Queries.GetAllBloodStocks;

public class GetAllBloodStocksQuery : IRequest<List<BloodStockViewModel>>
{
    public GetAllBloodStocksQuery(string query)
    {
        Query = query;
    }

    public string Query { get; private set; }
}
