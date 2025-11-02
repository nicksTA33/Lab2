namespace BankAccount.tests;

public class Money
{
    public Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public decimal Amount { get; set; }
    public Currency Currency { get; set; }
}
