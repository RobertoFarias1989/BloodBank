using BloodBank.Application.BloodStock.ViewModels;
using BloodBank.Core.Models;
using MediatR;

namespace BloodBank.Application.BloodStock.Queries.GetAllBloodStocks;

public class GetAllBloodStocksQuery : IRequest<PaginationResult<BloodStockViewModel>>
{
    public GetAllBloodStocksQuery(string query, int page)
    {
        Query = query;
        Page = page;
    }

    public string Query { get;  set; }
    public int Page { get; set; }
}
