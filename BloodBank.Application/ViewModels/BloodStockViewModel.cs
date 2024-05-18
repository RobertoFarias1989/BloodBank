using BloodBank.Core.Enums;

namespace BloodBank.Application.ViewModels
{
    public class BloodStockViewModel
    {
        public BloodStockViewModel(int id, string bloodType, string rHFactor)
        {
            Id = id;
            BloodType = bloodType;
            RHFactor = rHFactor;
        }

        public int Id { get; private set; }
        public string BloodType { get; private set; }
        public string RHFactor { get; private set; }
    }
}
