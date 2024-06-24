using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phowr.Core.Domain;

public static class MoneyExtensions
{
    public static bool IsGreaterThanZero(this Money money)
        => money.Amount > Money.ZeroAmount;

    public static bool IsLessThanZero(this Money money)
        => money.Amount < Money.ZeroAmount;

    public static bool IsZero(this Money money)
        => money.Amount == Money.ZeroAmount;

    public static bool IsLessThanOrEqualsToZero(this Money money)
        => money.Amount <= Money.ZeroAmount;

    public static bool EnsureTheSameCurrency(this Money actual, Money expected)
        => actual.EnsureTheSameCurrency(expected);

    public static Money GetTaxAmount(this Money money, Tax tax)
        => Money.Create(money.Amount * (decimal)tax.Percent, money.Currency);

    public static Money Sum(this IEnumerable<Money> source, MoneyCurrency currency)
        => new(source.Select(m => m.Amount).Sum(), currency);
}
