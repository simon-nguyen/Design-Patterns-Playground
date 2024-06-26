using Phowr.Core.Domain.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public class ShoppingCartItemBuilder
{
    private ISellingItem _item = default!;
    private int _quantity;

    public static ShoppingCartItemBuilder Create()
        => new();

    public ShoppingCartItemBuilder With(ISellingItem item)
    {
        _item = item ?? throw new ArgumentNullException(nameof(item));
        return this;
    }

    public ShoppingCartItemBuilder WithQuantity(int quantity)
    {
        _quantity = quantity;
        return this;
    }

    public IShoppingCartItem Build()
        => ShoppingCartItemBase.Create(_item, _quantity);
}
