using BloodBank.Application.ViewModels;
using MediatR;

namespace BloodBank.Application.Querys.GetBloodStockReport;

public class GetBloodStockReportQuery : IRequest<List<BloodStockReportViewModel>>
{
}
