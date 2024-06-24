using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phowr.Core.Domain;

public class NonZeroOrNegativeDiscount(IDiscount Other) : IDiscount
{
    /// <summary>
    /// Decorator that returns all the discounts with positive discount amount.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public IEnumerable<DiscountInfo> GetDiscountDetails(Money discountAmount)
        => Other.GetDiscountDetails(discountAmount).Where(d => d.DiscountAmount.IsGreaterThanZero());

    
    public IDiscount GetWithin(DiscountContext context)
        => new NonZeroOrNegativeDiscount(Other.GetWithin(context));
}
