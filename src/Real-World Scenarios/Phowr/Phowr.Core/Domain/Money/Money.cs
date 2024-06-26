﻿using System;
using System.Globalization;

namespace Phowr.Core.Domain;

public readonly record struct Money(decimal Amount, MoneyCurrency Currency)
{
    public const decimal ZeroAmount = 0.0m;

    public static Money Zero()
        => Zero(MoneyCurrency.Default());

    public static Money Zero(MoneyCurrency currency)
        => new(ZeroAmount, currency);

    public static Money Create(decimal amount, MoneyCurrency currency)
        => new(amount, currency);

    public static bool operator <=(Money a, Money b)
    {
        if (!EnsureTheSameCurrency(a, b))
            throw new InvalidOperationException("Cannot compare less than or equals to when the money currency is different.");

        return a.Amount <= b.Amount;
    }

    public static bool operator >=(Money a, Money b)
    {
        if (!EnsureTheSameCurrency(a, b))
            throw new InvalidOperationException("Cannot compare greater than or equals to when the money currency is different.");

        return a.Amount >= b.Amount;
    }

    public static Money operator +(Money money, decimal amount)
        => new(money.Amount + amount, money.Currency);

    public static Money operator +(Money based, Money adder)
    {
        if (!EnsureTheSameCurrency(based, adder))
            throw new InvalidOperationException("Cannot add when the money currency is different.");

        return based + adder.Amount;
    }

    public static Money operator -(Money money, decimal amount)
        => new(money.Amount - amount, money.Currency);

    public static Money operator -(Money based, Money adder)
    {
        if (!EnsureTheSameCurrency(based, adder))
            throw new InvalidOperationException("Cannot subtract when the money currency is different.");

        return based - adder.Amount;
    }

    public static Money operator *(Money money, int multiplier)
        => new(money.Amount * multiplier, money.Currency);

    public static Money operator *(Money money, double multiplier)
        => new(money.Amount * (decimal)multiplier, money.Currency);

    public static Money operator /(Money money, int multiplier)
        => new(money.Amount * multiplier, money.Currency);

    public static bool EnsureTheSameCurrency(Money a, Money b)
        => a.Currency == b.Currency;
}

public readonly record struct MoneyCurrency(string Code, string Symbol)
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
