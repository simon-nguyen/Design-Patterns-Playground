using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phowr.Core.Domain.UnitTests.Pocos.Discounts
{
    public class BuyOneGetOneForFreeDiscount
        : PhoOngGiaDamDangDiscountBase
    {
        private readonly List<string> _discountableItems = new();

        public BuyOneGetOneForFreeDiscount(IEnumerable<string> discountableItems)
            : this(discountableItems.ToArray())
        {
        }

        public BuyOneGetOneForFreeDiscount(params string[] discountableItems)
        {
            if (discountableItems is not null)
                _discountableItems.AddRange(discountableItems);
        }


        public override IEnumerable<DiscountInfo> GetDiscountDetails(Money discountAmount)
        {
            throw new NotImplementedException();
        }

        public override IDiscount GetWithin(PhoOngGiaDamDangDiscountContext context)
        {
            throw new NotImplementedException();
        }
    }
}
