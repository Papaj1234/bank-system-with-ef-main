using System.Globalization;
using BankSystem.Services.Helpers;

namespace BankSystem.Services.Generators;

public sealed class SimpleGenerator : IUniqueNumberGenerator
{
    private long lastNumber = 1234567890;

    static SimpleGenerator()
    {
        Instance = new SimpleGenerator();
    }

    private SimpleGenerator()
    {
    }

    public static SimpleGenerator Instance { get; }

    public string Generate()
    {
        long next = Interlocked.Increment(ref this.lastNumber);
        return next.ToString(CultureInfo.InvariantCulture).GenerateHash();
    }
}
