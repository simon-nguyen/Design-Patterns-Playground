using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public interface IShoppingCartItem
{
    ISellingItem Item { get; }

    int Quantity { get; }

    void Accept(IShoppingCartPricingVisitor visitor);
}
