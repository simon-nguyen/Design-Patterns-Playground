using System;
using System.Globalization;

namespace Phowr.Core.Domain;

public record struct Money(decimal Amount, MoneyCurrency Currency)
{
    public const decimal ZeroAmount = 0.0m;

    public static Money Zero()
        => new(ZeroAmount, MoneyCurrency.Default());

    public static Money Create(decimal amount, MoneyCurrency currency)
        => new(amount, currency);

    public static bool operator <=(Money a, Money b)
    {
        if (!EnsuresTheSameCurrency(a, b))
            throw new InvalidOperationException("Cannot compare less than or equals to when the money currency is different.");

        return a.Amount <= b.Amount;
    }

    public static bool operator >=(Money a, Money b)
    {
        if (!EnsuresTheSameCurrency(a, b))
            throw new InvalidOperationException("Cannot compare greater than or equals to when the money currency is different.");

        return a.Amount >= b.Amount;
    }

    private static bool EnsuresTheSameCurrency(Money a, Money b)
        => a.Currency == b.Currency;
}

public record struct MoneyCurrency(string Code, string Symbol)
{
    public static MoneyCurrency GetVietnameseCurrency
        => Get("VN");

    private static MoneyCurrency Get(string countryIso2)
    {
        var countryInfo = new RegionInfo(countryIso2);
        return new MoneyCurrency
        {
            Code = countryInfo.ISOCurrencySymbol,
            Symbol = countryInfo.CurrencySymbol
        };
    }

    public static MoneyCurrency Default()
    {
        var country = CultureInfo.CurrentCulture.LCID;
        var countryInfo = new RegionInfo(country);
        return new MoneyCurrency
        {
            Code = countryInfo.ISOCurrencySymbol,
            Symbol = countryInfo.CurrencySymbol
        };
    }
}
