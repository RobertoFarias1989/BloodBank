namespace BloodBank.Core.Erros
{
    public static class DonationErrors
    {
        public static readonly Error NotFound = new(
           "Donation.NotFound", "An active donation could not be found");

        public static readonly Error AlreadyInactived = new(
            "Donation.AlreadyInactived", "The donation is already inactived.");

        public static readonly Error MinumumMLDonate = new(
            "Donation.MinumumMLDonate", "Number of milliliters of blood donated must be between 420ml and 470ml.");
    }
}
