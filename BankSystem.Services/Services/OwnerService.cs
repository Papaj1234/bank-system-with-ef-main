using BankSystem.EF.Entities;
using BankSystem.Services.Models;

namespace BankSystem.Services.Services;

public class OwnerService : BaseService
{
    public OwnerService(BankContext bankContext)
        : base(bankContext)
    {
    }

    public IReadOnlyList<AccountOwnerTotalBalanceModel> GetAccountOwnersTotalBalance()
    {
        return this.Context.BankAccounts
            .Select(a => new
            {
                a.AccountOwnerId,
                a.AccountOwner.FirstName,
                a.AccountOwner.LastName,
                CurrencyCode = a.CurrencyCode.CurrenciesCode,
                a.Balance,
            })
            .AsEnumerable()
            .GroupBy(x => new { x.AccountOwnerId, x.FirstName, x.LastName, x.CurrencyCode })
            .Select(g => new AccountOwnerTotalBalanceModel
            {
                AccountOwnerId = g.Key.AccountOwnerId,
                FirstName = g.Key.FirstName,
                LastName = g.Key.LastName,
                CurrencyCode = g.Key.CurrencyCode,
                Total = g.Sum(x => x.Balance),
            })
            .OrderByDescending(m => m.Total)
            .ToList();
    }
}
