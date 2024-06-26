using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phowr.Core.Domain;

public class ShoppingCartBase
    : IShoppingCart
{
    private readonly List<IShoppingCartItem> _items = new();

    public MoneyCurrency Currency { get; set; }
    public Tax Tax { get; set; }
    public IDiscount? Discount { get; set; }

    public IReadOnlyList<IShoppingCartItem> Items => _items;

    public Money TotalNetPrice => this.GetCartTotalNetPrice(Currency, Tax, Discount);

    public static ShoppingCartBase Default(MoneyCurrency currency, Tax tax
        , IDiscount? discount = null
        , IEnumerable<IShoppingCartItem>? items = null)
    {
        var cart = new ShoppingCartBase
        {
            Currency = currency,
            Tax = tax,
            Discount = discount
        };

        if (items is not null)
        {
            cart._items.AddRange(items);
        }

        return cart;
    }

    public static ShoppingCartBase Default(MoneyCurrency currency, Tax tax
        , IDiscount? discount = null
        , params IShoppingCartItem[] items)
    {
        var cart = new ShoppingCartBase
        {
            Currency = currency,
            Tax = tax,
            Discount = discount
        };

        if (items is not null)
        {
            cart._items.AddRange(items);
        }

        return cart;
    }
}
