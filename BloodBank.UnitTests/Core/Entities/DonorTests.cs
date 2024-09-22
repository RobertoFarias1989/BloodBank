using BloodBank.Core.Entities;
using BloodBank.Core.Enums;
using BloodBank.Core.ValueObjects;

namespace BloodBank.UnitTests.Core.Entities
{
    public class DonorTests
    {
        [Fact]
        public void TestIfUpdateWorks()
        {
            //Arrange
            var donor = new Donor(
                new Name("José da Silva"),
                new CPF("55522299987"),
                new Email("joao.silva@email.com"),               
                new Password("StrongPassword123!"),
                "Donor",
                new DateTime(1990,5,1),
                GenderEnum.Male,
                75,
                BloodTypeEnum.O,
                RHFactorEnum.Positive,
                new Address("Rua Principal, 123", "São Paulo", "SP", "01000-000", "Brasil"));

            //Verifico se o construtor da classe está funcionando corretamente
            Assert.NotNull(donor);
            Assert.Equal("José da Silva", donor.Name.FullName);
            Assert.Equal("55522299987", donor.CPF.CPFNumber);
            Assert.Equal("joao.silva@email.com", donor.Email.EmailAddress);
            Assert.Equal("StrongPassword123!", donor.Password.PasswordValue);
            Assert.Equal("Donor", donor.Role);
            Assert.Equal(new DateTime(1990, 5, 1), donor.BirthDate);
            Assert.Equal(GenderEnum.Male, donor.Gender);
            Assert.Equal(75, donor.Weight);
            Assert.Equal(BloodTypeEnum.O, donor.BloodType);
            Assert.Equal(RHFactorEnum.Positive, donor.RHFactor);
            Assert.Equal(new Address("Rua Principal, 123", "São Paulo", "SP", "01000-000", "Brasil"), donor.Address);

            //Act
            donor.Update(
                new Name("João Silva"),
                new CPF("55522299987"),
                new Email("joao.silva@email.com"),                            
                new DateTime(1990, 5, 1),
                GenderEnum.Male,
                95,
                BloodTypeEnum.O,
                RHFactorEnum.Positive,
                new Address("Rua Principal, 123", "São Paulo", "SP", "01000-000", "Brasil"),
                new Password("StrongPassword123!"));

            //Assert
            Assert.Equal(DateTime.Now.Date, donor.UpdatedAt!.Value.Date);
            Assert.Equal("João Silva", donor.Name.FullName);
            Assert.Equal(95, donor.Weight);
        }

        [Fact]
        public void TestIfInactiveWorks()
        {
            //Arrange
            var donor = new Donor(
                new Name("José da Silva"),
                new CPF("55522299987"),
                new Email("joao.silva@email.com"),
                new Password("StrongPassword123!"),
                "Donor",
                new DateTime(1990, 5, 1),
                GenderEnum.Male,
                75,
                BloodTypeEnum.O,
                RHFactorEnum.Positive,
                new Address("Rua Principal, 123", "São Paulo", "SP", "01000-000", "Brasil"));

            //Verifico se não está null
            Assert.NotNull(donor);
            Assert.True(donor.IsActive);
            Assert.Null(donor.UpdatedAt);

            //Act: chamo o método Inactive
            donor.Inactive();

            //Assert: faço a verificação dos valores
            Assert.NotNull(donor);
            Assert.False(donor.IsActive);
            Assert.Equal(DateTime.Now.Date, donor.UpdatedAt!.Value.Date);

        }

        [Fact]
        public void TestIfAmIAbleToGiveBloodWorks()
        {
            //Arrange
            var donor = new Donor(
                new Name("José da Silva"),
                new CPF("55522299987"),
                new Email("joao.silva@email.com"),
                new Password("StrongPassword123!"),
                "Donor",
                new DateTime(1990, 5, 1),
                GenderEnum.Male,
                75,
                BloodTypeEnum.O,
                RHFactorEnum.Positive,
                new Address("Rua Principal, 123", "São Paulo", "SP", "01000-000", "Brasil"));

            //Verifico se não está null
            Assert.NotNull(donor);

            //Act
            var result = donor.AmIAbleToGiveBlood(donor);

            //Assert       
            Assert.True(result.Success);
            //Assert.False(result.Success);
        }
    }
}
