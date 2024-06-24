using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public interface IShoppingCartPricingVisitor
{
    Money TotalPrice { get; }
    Money DiscountPrice { get; }
    Money NetPrice { get; }

    void Visit(IShoppingCartItem item);
    void Visit(IDiscount discount);
    void Visit(Tax tax);
}
