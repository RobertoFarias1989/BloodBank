using BloodBank.Core.Enums;

namespace BloodBank.Core.Entities;

public class BloodStock : BaseEntity

{
    public BloodStock(BloodTypeEnum bloodType, RHFactorEnum factorRH, int quantityML) : base()
    {
        BloodType = bloodType;
        RHFactor = factorRH;
        QuantityML = quantityML;
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
}
