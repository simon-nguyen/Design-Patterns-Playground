using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public static class MoneyExtensions
{
    public static bool IsGreaterThanZero(this Money money)
        => money.Amount > 0;

    public static bool IsLessThanZero(this Money money)
        => money.Amount < 0;

    public static bool IsZero(this Money money)
        => money.Amount == Money.ZeroAmount;

    public static bool IsLessThanOrEqualsToZero(this Money money)
        => money.Amount <= Money.ZeroAmount;

    public static Money GetTaxAmount(this Money money, Tax tax)
        => Money.Create(money.Amount * tax.Percent / 100, money.Currency);
}
