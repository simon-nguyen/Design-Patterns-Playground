using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phowr.Core.Domain.UnitTests.Pocos.Discounts;

public abstract class PhoOngGiaDamDangDiscount : IDiscount
{
    public abstract IEnumerable<DiscountInfo> GetDiscountDetails(Money discountAmount);
    IDiscount IDiscount.GetWithin(DiscountContext context)
        => GetWithin(PhoOngGiaDamDangDiscountContext.Default());

    public virtual IDiscount GetWithin(PhoOngGiaDamDangDiscountContext context)
        => this;
}
