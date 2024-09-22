using BloodBank.Core.Entities;

namespace BloodBank.UnitTests.Core.Entities;

public class DonationTests
{
    [Fact]
    public void TestIfUpdateMLWorks()
    {
        //Arrange
        var donation = new Donation(450, 2);

        //Verifico se o construtor da classe está funcionando corretamente
        Assert.NotNull(donation);
        Assert.Equal(DateTime.Now.Date, donation.DonationDate.Date);
        Assert.Equal(DateTime.Now.Date, donation.CreatedAt.Date);
        Assert.True(donation.IsActive);
        Assert.Null(donation.UpdatedAt);

        //Act
        donation.UpdateML(500);

        //Assert
        Assert.Equal(500, donation.QuantityML);
        Assert.Equal(DateTime.Now.Date, donation.UpdatedAt!.Value.Date);

    }

    [Fact]
    public void TestIfInactiveWorks()
    {
        //Arrange
        var donation = new Donation(450, 2);

        //Verifico se não está null
        Assert.NotNull(donation);
        Assert.True(donation.IsActive);
        Assert.Null(donation.UpdatedAt);

        //Act: chamo o método Inactive
        donation.Inactive();

        //Assert: faço a verificação dos valores
        Assert.NotNull(donation);
        Assert.False(donation.IsActive);
        Assert.Equal(DateTime.Now.Date, donation.UpdatedAt!.Value.Date);

    }

    [Fact]
    public void TestIfAmountMillimeterToDonateWorks()
    {
        //Arrange
        var donation = new Donation(450, 2);

        //Verifico se não está null
        Assert.NotNull(donation);

        //Act
        var result = donation.AmountMillimeterToDonate(500);

        //Assert       
        //Assert.True(result.Success);
        Assert.False(result.Success);
    }
}
