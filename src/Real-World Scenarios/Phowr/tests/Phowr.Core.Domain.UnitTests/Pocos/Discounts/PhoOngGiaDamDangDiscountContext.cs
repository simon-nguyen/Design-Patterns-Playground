using Phowr.Core.Domain.UnitTests.Pocos.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phowr.Core.Domain.UnitTests.Pocos.Discounts;

public record PhoOngGiaDamDangDiscountContext(Pho BowlOfPho) : DiscountContext
{
    public static PhoOngGiaDamDangDiscountContext Default()
        => new(Pho.Empty());
}
