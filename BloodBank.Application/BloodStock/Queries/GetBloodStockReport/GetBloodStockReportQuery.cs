using BloodBank.Application.BloodStock.ViewModels;
using MediatR;

namespace BloodBank.Application.BloodStock.Queries.GetBloodStockReport;

public class GetBloodStockReportQuery : IRequest<List<BloodStockReportViewModel>>
{
}
