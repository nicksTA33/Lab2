using System.ComponentModel;

namespace BankAccount.tests;

public class BankAccount
{
    public Money Balance { get; private set; }

    public BankAccount(Money initialBalance)
    {
        Balance = initialBalance;
    }

    public void Replenish(Money amount) 
    {
        if (Balance.Currency != amount.Currency) 
        {
            throw new InvalidEnumArgumentException("Wrong currency");
        }
        
        Balance.Amount += amount.Amount;
    }
}
