using System.Linq;

namespace Phowr.Core.Domain;

public class ShoppingCartPricingCalculator(MoneyCurrency Currency) : IShoppingCartPricingVisitor
{
    private Money _calculatingPrice = Money.Zero(Currency);

    public Money TotalPrice { get; private set; }
    public Money DiscountPrice { get; private set; }
    public Money NetPrice { get; private set; }

    public void Visit(IShoppingCartItem item)
    {
        Money itemsTotalPrice = Money.Zero(Currency);
        itemsTotalPrice += item.GetItemTotalPrice();

        TotalPrice = _calculatingPrice = itemsTotalPrice;
    }

    public void Visit(IDiscount discount)
    {
        if (TotalPrice == Money.Zero()) return;

        var totalDiscount = discount.GetDiscountDetails(TotalPrice).Select(d => d.DiscountAmount).Sum(Currency);
        if (TotalPrice <= totalDiscount) return;

        DiscountPrice = _calculatingPrice = TotalPrice - totalDiscount;
    }

    public void Visit(Tax tax)
    {
        if (TotalPrice == Money.Zero()) return;

        NetPrice += _calculatingPrice.GetTaxAmount(tax);
    }
}
