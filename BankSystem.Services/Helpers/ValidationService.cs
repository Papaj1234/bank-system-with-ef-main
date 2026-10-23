using System.Globalization;
using System.Net.Mail;

namespace BankSystem.Services.Helpers;

public static class ValidationService
{
    private static readonly HashSet<string> Currencies = CultureInfo
        .GetCultures(CultureTypes.SpecificCultures)
        .Select(c => new RegionInfo(c.Name).ISOCurrencySymbol)
        .ToHashSet(StringComparer.Ordinal);

    public static bool IsCurrencyValid(this string currencyCode)
    {
        return !string.IsNullOrWhiteSpace(currencyCode) && Currencies.Contains(currencyCode);
    }

    public static bool IsEmailValid(this string email)
    {
        return !string.IsNullOrWhiteSpace(email)
            && MailAddress.TryCreate(email, out MailAddress? address)
            && address.Address == email;
    }
}
