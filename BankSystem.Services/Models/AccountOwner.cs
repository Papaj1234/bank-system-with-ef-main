using BankSystem.Services.Helpers;
using BankSystem.Services.Models.Accounts;

namespace BankSystem.Services.Models;

public class AccountOwner
{
    private readonly List<BankAccount> accounts = [];
    private string firstName = string.Empty;
    private string lastName = string.Empty;
    private string email = string.Empty;

    public AccountOwner(string firstName, string lastName, string email)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
    }

    public string FirstName
    {
        get => this.firstName;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            this.firstName = value;
        }
    }

    public string LastName
    {
        get => this.lastName;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            this.lastName = value;
        }
    }

    public string Email
    {
        get => this.email;
        set
        {
            if (!value.IsEmailValid())
            {
                throw new ArgumentException("Email is not valid.", nameof(value));
            }

            this.email = value;
        }
    }

    public void Add(BankAccount account)
    {
        ArgumentNullException.ThrowIfNull(account);
        this.accounts.Add(account);
    }

    public IList<BankAccount> Accounts() => this.accounts.AsReadOnly();

    public override string ToString() => $"{this.FirstName} {this.LastName}, {this.Email}.";
}
