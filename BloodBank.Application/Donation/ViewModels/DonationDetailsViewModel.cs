namespace BloodBank.Application.Donation.ViewModels;

public class DonationDetailsViewModel
{
    public DonationDetailsViewModel(int id, bool isActive, DateTime createdAt, DateTime? updatedAt, DateTime donationDate, int quantityML, int idDonor)
    {
        Id = id;
        IsActive = isActive;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DonationDate = donationDate;
        QuantityML = quantityML;
        IdDonor = idDonor;
    }

    public int Id { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime DonationDate { get; private set; }
    public int QuantityML { get; private set; }
    public int IdDonor { get; private set; }
}
