using Phowr.Core.Domain.UnitTests.Pocos.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phowr.Core.Domain.UnitTests.Pocos.Discounts;

public class PhoTenPercentDiscount(decimal DiscountPercent, string PhoName)
    : PhoOngGiaDamDangDiscount
{
    public override IEnumerable<DiscountInfo> GetDiscountDetails(Money discountAmount)
    {
        var info = new DiscountInfo(
            $"{DiscountPercent * 100}% off of {Pho.PhoTaiNam}"
            , discountAmount * DiscountPercent
        );
        yield return info;
    }

    public override IDiscount GetWithin(PhoOngGiaDamDangDiscountContext context)
        => context.BowlOfPho.Name.Equals(PhoName, StringComparison.InvariantCultureIgnoreCase)
            ? this
            : new NoDiscount();
}
