using BloodBank.Core.Enums;

namespace BloodBank.Core.Entities;

public class BloodStock : BaseEntity

{
    public BloodStock()
    {

    }
    public BloodStock(BloodTypeEnum bloodType, RHFactorEnum factorRH, int quantityML)
    {
        BloodType = bloodType;
        RHFactor = factorRH;
        QuantityML = quantityML;

        CreatedAt = DateTime.Now;
        IsActive = true;
        UpdatedAt = null;
    }

    public BloodTypeEnum BloodType { get; private set; }
    public RHFactorEnum RHFactor { get; private set; }
    public int QuantityML { get; private set; }

    public void Update(BloodTypeEnum bloodType, RHFactorEnum factorRH, int quantityML)
    {
        BloodType = bloodType;
        RHFactor = factorRH;
        QuantityML = quantityML;

        UpdatedAt = DateTime.Now;
    }

    public  void Inactive()
    {
        if (IsActive == true)
            IsActive = false;

        UpdatedAt = DateTime.Now;
    }
}
