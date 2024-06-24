using System.Collections.Generic;
using System.Linq;

namespace Phowr.Core.Domain;

public record NoDiscount : IDiscount
{
    public IDiscount GetWithin(DiscountContext context)
        => this;

    public IEnumerable<DiscountInfo> GetDiscountDetails(Money discountAmount)
        => Enumerable.Empty<DiscountInfo>();
}
