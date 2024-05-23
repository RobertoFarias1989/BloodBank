namespace BloodBank.Core.Entities;

public class Donation : BaseEntity
{
    public Donation()
    {

    }
    public Donation(int quantityML, int idDonor)
    {
        QuantityML = quantityML;
        IdDonor = idDonor;

        DonationDate = DateTime.Now;
        CreatedAt = DateTime.Now;
        IsActive = true;
        UpdatedAt = null;
    }

    public DateTime DonationDate { get; private set; }
    public int QuantityML { get; private set; }
    public int IdDonor { get; private set; }
    public Donor Donor { get; private set; }

    public void UpdateML(int quantityML)
    {
        QuantityML = quantityML;
    }

    public  void Inactive()
    {
        if (IsActive == true)
            IsActive = false;

        UpdatedAt = DateTime.Now;
    }

}
