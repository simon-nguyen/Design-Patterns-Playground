using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public interface IShoppingCart
{
    IReadOnlyCollection<IShoppingCartItem> Items { get; }
    Money TotalNetPrice { get; }
}
