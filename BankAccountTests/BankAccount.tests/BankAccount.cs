using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.tests;

public class BankAccount
{
    public Money Balance { get; private set; }

    public BankAccount(Money initialBalance)
    {
        this.Balance= initialBalance;
    }
    public void Withdraw(Money amount)
    {
        if (Balance.Amount < amount.Amount)
        {
            throw new InvalidOperationException("Insufficient funds");
        } 

        if (amount.Currency != Balance.Currency)
        {
            throw new InvalidEnumArgumentException("Wrong currency");
        }
    }
}
