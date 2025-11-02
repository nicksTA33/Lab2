using System.Security.Principal;

namespace BankAccount.tests;

public class BankAccountTests
{
    [Theory]
    [InlineData(1, 11)]
    [InlineData(2, 12)]
    public void Replenish_BalanceIncreases_Correctly(decimal moneyToAdd, decimal excpectedBalance)
    {
        var account = new BankAccount(new Money{Amount=10, Currency=Currency.USD });

        account.Replenish(new Money { Amount = moneyToAdd, Currency=Currency.USD });
        Assert.Equal(account.Balance.Amount, excpectedBalance);
    }
}