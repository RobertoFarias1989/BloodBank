using BloodBank.Application.ViewModels;
using MediatR;

namespace BloodBank.Application.Querys.GetAllBloodStocks;

public class GetAllBloodStocksQuery : IRequest<List<BloodStockViewModel>>
{
    public GetAllBloodStocksQuery(string query)
    {
        Query = query;
    }

    public string Query { get; private set; }
}
