namespace BloodBank.Application.ViewModels;

public class DonationViewModel
{
    public DonationViewModel(int id, DateTime donationDate, int quantityML, int idDonor)
    {
        Id = id;
        DonationDate = donationDate;
        QuantityML = quantityML;
        IdDonor = idDonor;
    }

    public int Id { get; private set; }
    public DateTime DonationDate { get; private set; }
    public int QuantityML { get; private set; }
    public int IdDonor { get; private set; }
}
