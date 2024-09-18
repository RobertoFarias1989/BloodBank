using BloodBank.Application.Donation.ViewModels;
using BloodBank.Core.Enums;

namespace BloodBank.Application.Donor.ViewModels;

public class DonorDetailsViewModel
{
    public DonorDetailsViewModel(int id,
        bool isActive,
        DateTime createdAt,
        DateTime? updatedAt,
        string fullName,
        string cPFNumber,
        string emailAddress,
        DateTime birthDate,
        string gender,
        double weight,
        string bloodType,
        string rHFactor,
        string street,
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
        FullName = fullName;
        CPFNumber = cPFNumber;
        EmailAddress = emailAddress;
        BirthDate = birthDate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RHFactor = rHFactor;
        Street = street;
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
    public string FullName { get; private set; }
    public string CPFNumber { get; private set; }
    public string EmailAddress { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Gender { get; private set; }
    public double Weight { get; private set; }
    public string BloodType { get; private set; }
    public string RHFactor { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }
    public string Country { get; private set; }
    public List<DonationDetailsViewModel> Donations { get; private set; }
}
