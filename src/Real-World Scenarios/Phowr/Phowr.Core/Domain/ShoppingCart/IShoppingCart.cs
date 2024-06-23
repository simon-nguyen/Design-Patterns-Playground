using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain.ShoppingCart
{
    public interface IShoppingCart
    {
        Money TotalPrice { get; }
    }
}
