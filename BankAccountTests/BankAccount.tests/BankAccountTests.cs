using System.ComponentModel;

namespace BankAccount.tests;

public class BankAccountTests
{
    private BankAccount _account = new(new Money(10, Currency.USD));

    [Theory]
    [InlineData(1, 11)]
    [InlineData(2, 12)]
    public void Replenish_BalanceIncreases_Correctly(decimal moneyToAdd, decimal excpectedBalance)
    {
        _account.Replenish(new Money(moneyToAdd, Currency.USD));
        Assert.Equal(_account.Balance.Amount, excpectedBalance);
    }

    [Fact]
    public void Replenish_WrongCurrency_ThrowsInvalidOperation()
    {
        var amount = new Money(5, Currency.EUR);
        Assert.Throws<InvalidEnumArgumentException>(() => _account.Replenish(amount));
    }

    [Fact]
    public void InterestAccrual_Non_PositiveInterestRate_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _account.InterestAccrual(-0.1m));
    }
}