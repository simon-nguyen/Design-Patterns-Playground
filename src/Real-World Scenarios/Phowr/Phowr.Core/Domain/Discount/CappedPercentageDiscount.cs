using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain.Discount
{
    public class CappedPercentageDiscount(decimal MaxDiscountAmount, IDiscount Other) : IDiscount
    {
        public IEnumerable<DiscountInfo> GetDiscountDetails(Money discountAmount)
        {
            Money remaining = discountAmount * MaxDiscountAmount;
            foreach (var discount in Other.GetDiscountDetails(discountAmount))
            {
                if (discount.DiscountAmount >= remaining)
                {
                    yield return discount with { DiscountAmount = remaining };
                    yield break;
                }

                yield return discount;
                remaining -= discountAmount;
            }
        }

        public IDiscount GetWithin(DiscountContext context)
            => new CappedPercentageDiscount(MaxDiscountAmount, Other.GetWithin(context));
    }
}
