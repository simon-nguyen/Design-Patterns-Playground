using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Phowr.Core.Domain;

public class ShoppingCartBuilder
{
    private MoneyCurrency _currency;
    private Tax _tax;

    public ShoppingCartWithTaxBuilder SetUp(MoneyCurrency currency, Tax tax)
    {
        _currency = currency;
        _tax = tax;

        return new ShoppingCartWithTaxBuilder(_currency, _tax);
    }

    public static ShoppingCartWithTaxBuilder CreateDefaultCartBuilder(MoneyCurrency currency, Tax tax)
        => new(currency, tax);
}

public class ShoppingCartWithTaxBuilder(MoneyCurrency currency, Tax tax)
{
    private readonly List<IShoppingCartItem> _items = new();

    public ShoppingCartWithTaxBuilder AddItem(Action<ShoppingCartItemBuilder> itemBuilderOptions)
    {
        var itemBuilder = ShoppingCartItemBuilder.Create();

        itemBuilderOptions(itemBuilder);

        _items.Add(itemBuilder.Build());

        return this;
    }

    /// <summary>
    /// We want to make sure that the returned cart has been configured with Currency and Tax.
    /// </summary>
    /// <returns></returns>
    public IShoppingCart Build()
    {
        return ShoppingCartBase.Default(currency, tax, null, _items);
    }
}
