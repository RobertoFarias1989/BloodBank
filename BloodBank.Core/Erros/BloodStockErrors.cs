namespace BloodBank.Core.Erros;

public static  class BloodStockErrors
{
    public static readonly Error NotFound = new(
           "BloodStock.NotFound", "The BloodStock could not be found");

    public static readonly Error AlreadyInactived = new(
            "BloodStock.AlreadyInactived", "The BloodStock is already inactived.");
}
