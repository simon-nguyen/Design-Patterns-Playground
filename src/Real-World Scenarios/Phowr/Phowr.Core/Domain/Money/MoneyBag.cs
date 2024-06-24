using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phowr.Core.Domain;

public class MoneyBag
{
    private readonly List<Money> _innerList = new();
    private Money _totalAmount;

    public MoneyBag(MoneyCurrency currency)
    {
        //_totalAmount = Money.Zero(currency);
        Currency = currency;
    }

    public MoneyCurrency Currency { get; private set; }

    public Money TotalAmount => _totalAmount;

    public bool Add(Money money)
    {
        if (_totalAmount.EnsureTheSameCurrency(money))
        {
            _innerList.Add(money);
            _totalAmount += money;

            return true;
        }

        return false;
    }

    private void GetTotalAmount()
    {
        var x = _innerList.Aggregate(Money.Zero(), (total, money) => total += money);
    }

    private static bool EnsureTheSameCurrency(MoneyBag actual, MoneyBag expected)
        => actual.Currency == expected.Currency;

}
