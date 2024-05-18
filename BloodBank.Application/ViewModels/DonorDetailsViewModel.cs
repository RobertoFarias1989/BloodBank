using BloodBank.Core.Enums;

namespace BloodBank.Application.ViewModels
{
    public class DonorDetailsViewModel
    {
        public DonorDetailsViewModel(int id,
            bool isActive,
            DateTime createdAt,
            DateTime? updatedAt,
            string firstName,
            string lastName,
            string number,
            string emailAddress,
            DateTime birthDate,
            string gender,
            double weight,
            string bloodType,
            string rHFactor,
            string address1,
            string? address2,
            string city,
            string state,
            string postalCode,
            string country,
            List<DonationDetailsViewModel> donations)
        {
            Id = id;
            IsActive = isActive;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            FirstName = firstName;
            LastName = lastName;
            Number = number;
            EmailAddress = emailAddress;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RHFactor = rHFactor;
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
            Donations = donations;
        }

        public int Id { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Number { get; private set; }
        public string EmailAddress { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public string BloodType { get; private set; }
        public string RHFactor { get; private set; }
        public string Address1 { get; private set; }
        public string? Address2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }
        public List<DonationDetailsViewModel> Donations { get; private set; }
    }
}
