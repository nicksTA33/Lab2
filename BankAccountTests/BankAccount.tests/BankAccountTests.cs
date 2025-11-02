
using System.ComponentModel;

namespace BankAccount.tests;

public class BankAccountTests
{
    private BankAccount _account = new(new(10, Currency.USD));

    [Fact]
    public void Withdraw_WithdrawingMoreThanAvailable_ThrowsInvalidOperation()
    {
        var amount = new Money(10, Currency.USD);
        var account = new BankAccount(new Money(5, Currency.USD));

        Assert.Throws<InvalidOperationException>(() => account.Withdraw(amount));

    }

    [Fact]
    public void Withdraw_WithdrawWrongCurrency_ThrowsInvalidOperation()
    {
        var amount = new Money(5, Currency.UAH);
        Assert.Throws<InvalidEnumArgumentException>(() => _account.Withdraw(amount));
    }

    [Theory]
    [InlineData(1, 9)]
    [InlineData(2, 8)]
    public void Withdraw_BalanceDecreases_Correctly(decimal money, decimal expected)
    {
        _account.Withdraw(new Money(money, Currency.USD));
        Assert.Equal(_account.Balance.Amount, expected);
    }

    [Fact]
    public void MoneyAmount_NegativeAmount_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Money(-1, Currency.UAH));
    }

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

    [Theory]
    [InlineData(0.1, 11)]
    [InlineData(0.2, 12)]
    public void InterestAccrual_BalanceIncreases_Correctly(decimal interestRate, decimal excpected)
    {
        _account.InterestAccrual(interestRate);
        Assert.Equal(_account.Balance.Amount, excpected);
    }
}