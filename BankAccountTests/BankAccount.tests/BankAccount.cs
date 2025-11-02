using System.ComponentModel;

namespace BankAccount.tests;

public class BankAccount
{
    public Money Balance { get; private set; }

    public BankAccount(Money initialBalance)
    {
        Balance = initialBalance;
    }

    public void Replenish(Money amount) =>
        Balance = (Balance.Currency == amount.Currency) switch
        {
            true => new(amount.Amount + Balance.Amount, Balance.Currency),
            _ => throw new InvalidEnumArgumentException("Wrong currency")
        };

    public void InterestAccrual(decimal interestRate) => throw new NotImplementedException();
}
