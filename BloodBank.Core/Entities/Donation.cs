using BloodBank.Core.Erros;
using BloodBank.Core.Results;

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

    private const int MinimumML = 420;

    private const int MaximumML = 470;

    public void UpdateML(int quantityML)
    {
        QuantityML = quantityML;

        UpdatedAt = DateTime.Now;
    }

    public  void Inactive()
    {
        if (IsActive == true)
            IsActive = false;

        UpdatedAt = DateTime.Now;
    }

    public Result AmountMillimeterToDonate(int quantityML)
    {
        //Quantidade de mililitros de sangue doados deve ser entre 420ml e 470ml
        if (quantityML < MinimumML || quantityML > MaximumML)           
            return Result.Fail(DonationErrors.MinumumMLDonate);

        return Result.Ok();
    }

}
