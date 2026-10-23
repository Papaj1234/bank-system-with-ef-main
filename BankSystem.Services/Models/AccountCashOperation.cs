using System.Globalization;

namespace BankSystem.Services.Models;

public class AccountCashOperation
{
    public AccountCashOperation(decimal amount, DateTime date, string note)
    {
        this.Amount = amount;
        this.Date = date;
        this.Note = note;
    }

    public decimal Amount { get; }

    public DateTime Date { get; }

    public string Note { get; }

    public override string ToString()
    {
        string date = this.Date.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        string amount = this.Amount.ToString(CultureInfo.InvariantCulture);

        return this.Amount < 0
            ? $"{date} {this.Note} : Debited from account {amount}."
            : $"{date} {this.Note} : Credited to account {amount}.";
    }
}
