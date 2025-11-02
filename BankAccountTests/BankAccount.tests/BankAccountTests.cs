
using System.ComponentModel;

namespace BankAccount.tests
{
    public class BankAccountTests
    {
        BankAccount _account = new BankAccount(new Money { Amount = 10, Currency = Currency.EUR });

        [Fact]
        public void Withdraw_WithdrawingMoreThanAvailable_ThrowsInvalidOperation()
        {
            var amount = new Money { Amount = 10, Currency = Currency.USD };
            var account = new BankAccount(new Money { Amount = 5, Currency = Currency.USD });

            Assert.Throws<InvalidOperationException>(() => account.Withdraw(amount));
           
        }

        [Fact]

        public void Withdraw_WithdrawWrongCurrency_ThrowsInvalidOperation()
        {
            var amount = new Money { Amount = 5, Currency = Currency.UAH };
            Assert.Throws<InvalidEnumArgumentException>(() => _account.Withdraw(amount));
        }

    }
}