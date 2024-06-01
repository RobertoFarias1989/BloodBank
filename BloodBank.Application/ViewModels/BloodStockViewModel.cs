using BloodBank.Core.Enums;

namespace BloodBank.Application.ViewModels;

public class BloodStockViewModel
{
    public BloodStockViewModel(int id, string bloodType, string rHFactor, int idDonation, string validateUntil)
    {
        Id = id;
        BloodType = bloodType;
        RHFactor = rHFactor;
        IdDonation = idDonation;
        ValidateUntil = validateUntil;
    }

    public int Id { get; private set; }
    public string BloodType { get; private set; }
    public string RHFactor { get; private set; }
    public string ValidateUntil { get; private set; }
    public int IdDonation { get; private set; }

}
