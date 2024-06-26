using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phowr.Core.Domain.UnitTests.Pocos.ShoppingCarts;

public class PhoOngGiaDamDangShoppingCart(MoneyCurrency currency, Tax tax, IDiscount? discount)
    : ShoppingCartBase(currency, tax, discount)
{
}
