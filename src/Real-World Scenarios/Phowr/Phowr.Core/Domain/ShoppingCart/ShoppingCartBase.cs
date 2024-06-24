using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phowr.Core.Domain;

public class ShoppingCartBase : IShoppingCart
{
    private readonly List<IShoppingCartItem> _items = new();

    public ShoppingCartBase(MoneyCurrency currency, Tax tax, IDiscount? discount = null)
    {
        Currency = currency;
        Tax = tax;
        Discount = discount;
    }

    public MoneyCurrency Currency { get; private set; }
    public Tax Tax { get; private set; }
    public IDiscount? Discount { get; private set; }

    public IReadOnlyCollection<IShoppingCartItem> Items => _items;

    public Money TotalNetPrice => this.GetCartTotalNetPrice(Currency, Tax, Discount);
}
