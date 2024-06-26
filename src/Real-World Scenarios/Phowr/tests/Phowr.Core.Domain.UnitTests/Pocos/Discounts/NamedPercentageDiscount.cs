using System;
using System.Collections.Generic;

namespace Phowr.Core.Domain.UnitTests.Pocos.Discounts;

public class PercentageDiscount(decimal discountPercent) : PhoOngGiaDamDangDiscountBase
{
    public decimal DiscountPercentage { get; } = discountPercent <= 0 || discountPercent > 1
        ? discountPercent
        : throw new ArgumentOutOfRangeException($"The percentage discount value should be between 0 and 1. Your input was '{discountPercent}'");

    public override IEnumerable<DiscountInfo> GetDiscountDetails(Money discountAmount)
    {
        yield return new DiscountInfo(
            $"{DiscountPercentage * 100}% discount",
            discountAmount * DiscountPercentage);
    }

    public override IDiscount GetWithin(PhoOngGiaDamDangDiscountContext context)
        => this;
}

public class NamedPercentageDiscount(decimal discountPercent, string itemName)
    : PercentageDiscount(discountPercent)
{
    public string ItemName { get; } = string.IsNullOrWhiteSpace(itemName)
        ? itemName
        : throw new ArgumentNullException(nameof(itemName));

    public override IEnumerable<DiscountInfo> GetDiscountDetails(Money discountAmount)
    {
        yield return new DiscountInfo(
            $"{DiscountPercentage * 100}% off of {ItemName}",
            discountAmount * DiscountPercentage);
    }

    public override IDiscount GetWithin(PhoOngGiaDamDangDiscountContext context)
        => context.BowlOfPho.Name.Equals(ItemName, StringComparison.InvariantCultureIgnoreCase)
            ? this
            : new NoDiscount();
}
