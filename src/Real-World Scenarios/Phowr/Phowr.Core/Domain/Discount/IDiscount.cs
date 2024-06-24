using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public interface IDiscount
{
    IDiscount GetWithin(DiscountContext context);
    IEnumerable<DiscountInfo> GetDiscountDetails(Money price);
}

public record DiscountInfo(string Label, Money DiscountAmount)
{
}

public record DiscountContext
{
}
