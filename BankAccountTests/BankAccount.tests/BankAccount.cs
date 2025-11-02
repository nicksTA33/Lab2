using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.tests;


/// <summary>
/// Represents a balance of personal bank account 
/// </summary>
public class BankAccount
{
    public Money Balance { get; private set; }

    public BankAccount(Money initialBalance)
    {
        this.Balance= initialBalance;
    }

    /// <summary>
    /// Withdraws money from balance <br/>
    /// Throws exception if wrong currency is used or balance has insufficient funds
    /// </summary>
    /// <param name="amount"></param>
    /// <exception cref="InvalidOperationException"></exception>

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

        Balance = new Money(Balance.Amount - amount.Amount, Balance.Currency);
    }
}
