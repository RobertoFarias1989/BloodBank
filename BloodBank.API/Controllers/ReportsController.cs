using BloodBank.Application.BloodStock.Queries.GetBloodStockReport;
using BloodBank.Application.BloodStock.ViewModels;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BloodBank.API.Controllers;

[Route("api/reports")]
[ApiController]
public class ReportsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("blood-stock")]
    [HttpGet]
    public async Task<IActionResult> ReportBloodStock()
    {
        var getAllBloodStocksQuery = new GetBloodStockReportQuery();

        var bloodStock = await _mediator.Send(getAllBloodStocksQuery);

        var webReport = new WebReport();

        webReport.Report.Load(Path.Combine("reports", "bloodStockReport.frx"));

        GenerateDataTableReport(bloodStock, webReport);

        webReport.Report.Prepare();

        using MemoryStream stream = new MemoryStream();

        webReport.Report.Export(new PDFSimpleExport(), stream);

        stream.Flush();

        byte[] arrayReport = stream.ToArray()
;
        return File(arrayReport, "application/zip", "BloodStockReport.pdf");
    }

    private void GenerateDataTableReport(List<BloodStockReportViewModel> bloodStock, WebReport webReport)
    {
        var bloodStockDataTable = new DataTable();

        bloodStockDataTable.Columns.Add("BloodType", typeof(string));
        bloodStockDataTable.Columns.Add("RHFactor", typeof(string));
        bloodStockDataTable.Columns.Add("QuantityML", typeof(int));

        foreach(var item in bloodStock)
        {
            bloodStockDataTable.Rows.Add(item.BloodType, item.RHFactor, item.QuantityML);
        }

        webReport.Report.RegisterData(bloodStockDataTable, "BloodStockReport");
    }
}
