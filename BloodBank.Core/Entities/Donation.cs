namespace BloodBank.Core.Entities;

public class Donation : BaseEntity
{
    public Donation(int quantityML, int idDonor) : base()
    {
        QuantityML = quantityML;
        IdDonor = idDonor;

        DonationDate = DateTime.Now;
    }

    public DateTime DonationDate { get; private set; }
    public int QuantityML { get; private set; }
    public int IdDonor { get; private set; }
    public Donor Donor { get; private set; }

    public void UpdateML(int quantityML)
    {
        QuantityML = quantityML;
    }

}
