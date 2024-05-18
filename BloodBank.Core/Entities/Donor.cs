using BloodBank.Core.Enums;
using BloodBank.Core.ValueObjects;

namespace BloodBank.Core.Entities
{
    public class Donor : BaseEntity
    {
        public Donor(Name name,
            CPF cpf,
            Email email,
            DateTime birthDate,
            GenderEnum gender,
            double weight,
            BloodTypeEnum bloodType,
            RHFactorEnum rHFactor,
            Address address) : base()
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
        }

        public void Inactived(bool isActive)
        {
            IsActive = isActive;
        }
    }
}
