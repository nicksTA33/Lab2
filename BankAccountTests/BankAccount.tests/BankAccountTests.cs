using System.ComponentModel;

namespace BankAccount.tests;

public class BankAccountTests
{
    private BankAccount _account = new(new Money{ Amount=10, Currency=Currency.USD });

    [Theory]
    [InlineData(1, 11)]
    [InlineData(2, 12)]
    public void Replenish_BalanceIncreases_Correctly(decimal moneyToAdd, decimal excpectedBalance)
    {
        _account.Replenish(new Money { Amount = moneyToAdd, Currency=Currency.USD });
        Assert.Equal(_account.Balance.Amount, excpectedBalance);
    }

    [Fact]
    public void Replenish_WrongCurrency_ThrowsInvalidOperation()
    {
        var amount = new Money() { Amount=5, Currency=Currency.EUR };
        Assert.Throws<InvalidEnumArgumentException>(() => _account.Replenish(amount));
    }
}