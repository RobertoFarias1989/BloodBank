using BloodBank.Core.Enums;
using BloodBank.Core.ValueObjects;
using System.Drawing;

namespace BloodBank.Core.Entities;

public class Donor : BaseEntity
{
    public Donor()
    {

    }
    public Donor(Name name,
        CPF cpf,
        Email email,
        DateTime birthDate,
        GenderEnum gender,
        double weight,
        BloodTypeEnum bloodType,
        RHFactorEnum rHFactor,
        Address address)
    {
        Name = name;
        CPF = cpf;
        Email = email;
        BirthDate = birthDate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RHFactor = rHFactor;
        Address = address;

        Donations = new List<Donation>();
        CreatedAt = DateTime.Now;
        IsActive = true;
        UpdatedAt = null;
    }

    public Name Name { get; private set; }
    public CPF CPF { get; private set; }
    public Email Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public GenderEnum Gender  { get; private set; }
    public double Weight { get; private set; }
    public BloodTypeEnum BloodType { get; private set; }
    public RHFactorEnum RHFactor { get; private set; }
    public Address Address { get; private set; }
    public List<Donation> Donations { get; private set; }

    private const int MinimumAge = 16;

    private const int MaximumAge = 69;

    private const int MinimumWeight = 50;


    public void Update(Name name,
        CPF cpf,
        Email email, DateTime birthDate, GenderEnum gender, double weight, BloodTypeEnum bloodType, RHFactorEnum rHFactor, Address address )
    {
        Name = name;
        CPF = cpf;
        Email = email;
        BirthDate = birthDate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RHFactor = rHFactor;
        Address = address;

        UpdatedAt = DateTime.Now;
    }

    public  void Inactive()
    {
        if (IsActive == true)
            IsActive = false;

        UpdatedAt = DateTime.Now;
    }

    public void AgeAvailable(DateTime birthDate)
    {
        //Menor de idade não pode doar, mas pode ter cadastro.
        var today = DateTime.Today;

        var age = today.Year - birthDate.Year;

        if (age < MinimumAge && age > MaximumAge)
            throw new Exception("You must have age between 16 and 69.");
    }

    public void MinimunWeight(double weight)
    {
        //Pesar no mínimo 50KG.
        if (weight < MinimumWeight)
            throw new Exception("You must have more than 50kg.");
    }

    public void AmIAbleToGiveBlood(Donor donor)
    {
        //Menor de idade não pode doar, mas pode ter cadastro.
        var today = DateTime.Today;

        var age = today.Year - donor.BirthDate.Year;

        if (age < MinimumAge && age > MaximumAge)
            throw new Exception("You must have age between 16 and 69.");

        //Pesar no mínimo 50KG.
        if (donor.Weight < MinimumWeight)
            throw new Exception("You must have more than 50kg.");


        //Mulheres só podem doar de 90 em 90 dias.(PLUS)
        if (donor.Gender == GenderEnum.Female && donor.Donations != null)
        {
            var lastDonation = donor.Donations.OrderByDescending(dt => dt.Id).Select(dt => dt.DonationDate).First();

            var diferrence = today - lastDonation;

            var days = diferrence.Days;

            if (days < 90)
                throw new Exception("Women can only donate every 90 days.");
        }

        //Homens só podem doar de 60 em 60 dias.
        if (donor.Gender == GenderEnum.Male && donor.Donations != null)
        {
            var lastDonation = donor.Donations.OrderByDescending(dt => dt.Id).Select(dt => dt.DonationDate).First();

            var diferrence = today - lastDonation;

            var days = diferrence.Days;

            if (days < 60)
                throw new Exception("Men can only donate every 60 days.");
        }
    }

}
