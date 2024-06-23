using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public interface IShoppingCartVisitor
{
    void Visit(IShoppingCartItem item);
}
