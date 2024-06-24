using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public record PercentageDiscount : IDiscount
{
    public PercentageDiscount(decimal factor)
    {
        if (factor < 0 || factor > 1)
            throw new ArgumentOutOfRangeException(nameof(factor), "Discount factor should be between 0 and 1.");

        Factor = factor;
    }

    public decimal Factor { get; private set; }

    public IDiscount GetWithin(DiscountContext context)
        => this;

    public IEnumerable<DiscountInfo> GetDiscountDetails(Money discountAmount)
    {
        yield return new DiscountInfo($"Discount {Factor:P2}", discountAmount * Factor);
    }
}
