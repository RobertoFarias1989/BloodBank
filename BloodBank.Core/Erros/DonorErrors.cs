namespace BloodBank.Core.Erros
{
    public static class DonorErrors
    {
        public static readonly Error NotFound = new(
            "Donor.NotFound", "An active donor could not be found");

        public static readonly Error AlreadyInactived = new(
           "Donor.AlreadyInactived", "The donor is already inactived.");

        public static readonly Error RangeAge = new(
          "Donor.RangeAge", "The donor range in age must in from 16 to 69.");

        public static readonly Error MinimumWeight = new(
          "Donor.MinimumWeight", "The donor must have more than 50kg.");

        public static readonly Error WomenRangeDays = new(
         "Donor.WomenRangeDays", "Women can only donate every 90 days.");

        public static readonly Error MenRangeDays = new(
         "Donor.MenRangeDays", "Men can only donate every 60 days.");
    }
}
