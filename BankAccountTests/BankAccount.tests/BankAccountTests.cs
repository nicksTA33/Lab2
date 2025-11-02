
using System.ComponentModel;

namespace BankAccount.tests
{
    public class BankAccountTests
    {
        BankAccount _account = new BankAccount(new Money(10, Currency.EUR));

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

    }
}