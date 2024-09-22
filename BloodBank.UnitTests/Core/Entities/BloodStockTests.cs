using BloodBank.Core.Entities;
using BloodBank.Core.Enums;

namespace BloodBank.UnitTests.Core.Entities;

public class BloodStockTests
{
    [Fact]
    public void TestIfBloodStockUpdateWorks()
    {
        //Arrange
        var bloodStock = new BloodStock(BloodTypeEnum.A, RHFactorEnum.Positive, 500, 1);

        //Verifico se o construtor da classe está funcionando
        Assert.NotNull(bloodStock);
        Assert.Equal(DateTime.Now.Date, bloodStock.CreatedAt.Date);
        Assert.Null(bloodStock.UpdatedAt);
        Assert.True(bloodStock.IsActive);
        Assert.Equal(DateTime.Now.AddDays(35).Date, bloodStock.ValidateUntil.Date);

        //Act : chamo o método update
        bloodStock.Update(BloodTypeEnum.O, RHFactorEnum.Negative, 480);

        //Assert: verifico se as atualizações foram de fato realizadas
        Assert.NotNull(bloodStock);
        Assert.Equal(DateTime.Now.Date, bloodStock.UpdatedAt!.Value.Date);
        Assert.Equal(BloodTypeEnum.O, bloodStock.BloodType);
        Assert.Equal(RHFactorEnum.Negative, bloodStock.RHFactor);

    }

    [Fact]
    public void TestIfInactiveWorks()
    {
        //Arrange
        var bloodStock = new BloodStock(BloodTypeEnum.A, RHFactorEnum.Positive, 500, 1);

        //Verifico se não está null
        Assert.NotNull(bloodStock);
        Assert.True(bloodStock.IsActive);
        Assert.Null(bloodStock.UpdatedAt);

        //Act: chamo o método Inactive
        bloodStock.Inactive();

        //Assert: faço a verificação dos valores
        Assert.NotNull(bloodStock);
        Assert.False(bloodStock.IsActive);
        Assert.Equal(DateTime.Now.Date, bloodStock.UpdatedAt!.Value.Date);

    }

    [Fact]
    public void TestIfIncreaseAmountWorks()
    {
        //Arrange
        var bloodStock = new BloodStock(BloodTypeEnum.A, RHFactorEnum.Positive, 500, 1);

        //Verifico se não está null
        Assert.NotNull(bloodStock);

        //Act: chamo o IncreaseAmount
        bloodStock.IncreaseAmount(100);

        //Assert
        Assert.Equal(600, bloodStock.QuantityML);
    }


    [Fact]
    public void TestIfConsumeAmountWorks()
    {
        //Arrange
        var bloodStock = new BloodStock(BloodTypeEnum.A, RHFactorEnum.Positive, 500, 1);

        //Verifico se não está null
        Assert.NotNull(bloodStock);

        //Act: chamo o IncreaseAmount
        bloodStock.ConsumeAmount(100);

        //Assert
        Assert.Equal(400, bloodStock.QuantityML);
    }

    [Fact]
    public void TestIfUpdateAmountWorks()
    {
        //Arrange
        var bloodStock = new BloodStock(BloodTypeEnum.A, RHFactorEnum.Positive, 500, 1);

        //Verifico se não está null
        Assert.NotNull(bloodStock);

        //Act: chamo o IncreaseAmount
        bloodStock.UpdateAmount(480);

        //Assert
        Assert.Equal(480, bloodStock.QuantityML);
        Assert.Equal(DateTime.Now.Date, bloodStock.UpdatedAt!.Value.Date);
    }
}
