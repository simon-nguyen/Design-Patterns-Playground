using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public static class ShoppingCartExtensions
{
    public static Money GetItemTotalPrice(this IShoppingCartItem item)
        => item.Item.UnitPrice * item.Quantity;

    /// <summary>
    /// Returns the after tax(es) price of all <see cref="IShoppingCart.Items"/> and all discount(s) subtracted.
    /// </summary>
    /// <param name="cart"></param>
    /// <param name="currency"></param>
    /// <param name="tax"></param>
    /// <param name="discount"></param>
    /// <returns></returns>
    public static Money GetCartTotalNetPrice(this IShoppingCart cart, MoneyCurrency currency, Tax tax, IDiscount? discount = null)
    {
        var calculator = new ShoppingCartPricingCalculator(currency);

        foreach (var item in cart.Items)
        {
            item.Accept(calculator);
        }

        if (discount != null)
        {
            calculator.Visit(discount);
        }

        calculator.Visit(tax);


        return calculator.NetPrice;
    }
}
