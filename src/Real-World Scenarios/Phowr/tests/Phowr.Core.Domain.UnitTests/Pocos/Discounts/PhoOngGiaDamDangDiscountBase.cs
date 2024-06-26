using System.Collections.Generic;

namespace Phowr.Core.Domain.UnitTests.Pocos.Discounts;

public abstract class PhoOngGiaDamDangDiscountBase : IDiscount
{
    public abstract IEnumerable<DiscountInfo> GetDiscountDetails(Money discountAmount);

    IDiscount IDiscount.GetWithin(DiscountContext context)
        => GetWithin(PhoOngGiaDamDangDiscountContext.Default());

    public virtual IDiscount GetWithin(PhoOngGiaDamDangDiscountContext context)
        => new NoDiscount();
}
