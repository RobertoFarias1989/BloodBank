namespace BloodBank.Application.BloodStock.ViewModels;

public class BloodStockReportViewModel
{
    public BloodStockReportViewModel(string bloodType, string rHFactor, int quantityML)
    {
        BloodType = bloodType;
        RHFactor = rHFactor;
        QuantityML = quantityML;
    }

    public string BloodType { get; private set; }
    public string RHFactor { get; private set; }
    public int QuantityML { get; private set; }
}
