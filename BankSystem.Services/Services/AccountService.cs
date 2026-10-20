using BankSystem.EF.Entities;
using BankSystem.Services.Models;

namespace BankSystem.Services.Services;

public class AccountService : BaseService
{
    public AccountService(BankContext bankContext)
        : base(bankContext)
    {
    }

    public IReadOnlyList<BankAccountFullInfoModel> GetBankAccountsFullInfo()
    {
        return this.Context.BankAccounts
            .Select(a => new BankAccountFullInfoModel
            {
                BankAccountId = a.Id,
                FirstName = a.AccountOwner.FirstName,
                LastName = a.AccountOwner.LastName,
                AccountNumber = a.Number,
                Balance = a.Balance,
                CurrencyCode = a.CurrencyCode.CurrenciesCode,
                BonusPoints = a.BonusPoints,
            })
            .ToList();
    }
}
