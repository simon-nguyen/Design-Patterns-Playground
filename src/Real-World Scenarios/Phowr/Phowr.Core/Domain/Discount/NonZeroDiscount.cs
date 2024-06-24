using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain.Discount
{
    public class NonZeroDiscount : IDiscount
    {
        private IDiscount _discount;
        public NonZeroDiscount(IDiscount discount)
        {
            _discount = discount;
        }

        public Money DiscountAmount => _discount.DiscountAmount;
    }
}
