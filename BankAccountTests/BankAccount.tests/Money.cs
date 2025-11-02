using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.tests
{
    public class Money
    {
        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            private init => _amount = (value < 0) ? throw new ArgumentException("Amount can't be negative") : value;

        }

        public Currency Currency { get; private init; }

        public Money(decimal amount, Currency currency) 
        { 
            Amount = amount;
            Currency = currency;
        }

        
        
    }
}
