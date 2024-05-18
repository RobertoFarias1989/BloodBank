namespace BloodBank.Application.ViewModels
{
    public class BloodStockDetailsViewModel
    {
        public BloodStockDetailsViewModel(int id, bool isActive, DateTime createdAt, DateTime? updatedAt, string bloodType, string rHFactor, int quantityML)
        {
            Id = id;
            IsActive = isActive;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            BloodType = bloodType;
            RHFactor = rHFactor;
            QuantityML = quantityML;
        }

        public int Id { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string BloodType { get; private set; }
        public string RHFactor { get; private set; }
        public int QuantityML { get; private set; }
    }
}
