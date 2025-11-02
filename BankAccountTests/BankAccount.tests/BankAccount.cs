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
        throw new NotImplementedException();
    }
}
