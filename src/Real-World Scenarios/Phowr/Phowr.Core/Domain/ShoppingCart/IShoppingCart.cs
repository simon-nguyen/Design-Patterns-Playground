using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public interface IShoppingCart
{
    IReadOnlyList<IShoppingCartItem> Items { get; }
    Money TotalNetPrice { get; }
}
