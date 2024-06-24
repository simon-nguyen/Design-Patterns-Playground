using Phowr.Core.Domain.Discount;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Phowr.Core.Domain;

public record CompositeDiscount : IDiscount
{
    private readonly List<IDiscount> _discounts = new();

    public CompositeDiscount(IEnumerable<IDiscount> discounts)
    {
        if (discounts is null)
        {
            _discounts.Add(new NoDiscount());
        }
        else
        {
            _discounts.AddRange(discounts);
        }
    }

    public CompositeDiscount(params IDiscount[] discounts)
    {
        if (discounts is null)
        {
            _discounts.Add(new NoDiscount());
        }
        else
        {
            _discounts.AddRange(discounts);
        }
    }

    public IReadOnlyList<IDiscount> Discounts => _discounts;

    public IDiscount GetWithin(DiscountContext context)
        => new CompositeDiscount(_discounts.Select(d => d.GetWithin(context)));

    public IEnumerable<DiscountInfo> GetDiscountDetails(Money discountAmount)
    {
        Money remaining = discountAmount;
        foreach (var discount in _discounts)
        {
            foreach (var discountable in discount.GetDiscountDetails(discountAmount))
            {
                yield return discountable;
                remaining -= discountable.DiscountAmount;
            }
        }
    }

    /// <summary>
    /// Factory Method that returns discount(s) after purged and flatten the input discounts.
    /// </summary>
    /// <param name="discounts"></param>
    /// <returns>
    /// <para>A <see cref="NoDiscount"/> if the purged list is empty - Null Object pattern.</para>
    /// <para>The only discount in the purged list.</para>
    /// <para>A <see cref="CappedPercentageDiscount" /> as a container (Decorator) of all the discounts in the list wrapped in a <see cref="CompositeDiscount"/>.</para>
    /// </returns>
    public static IDiscount Create(IEnumerable<IDiscount> discounts)
    {
        var purgedFlattenDiscounts = Purge(Flatten(discounts)).ToList();

        if (purgedFlattenDiscounts.Count == 0)
            return new NoDiscount();

        if (purgedFlattenDiscounts.Count == 1)
            return purgedFlattenDiscounts.First();

        return new CappedPercentageDiscount(1, new CompositeDiscount(purgedFlattenDiscounts));
    }

    private static IEnumerable<IDiscount> Purge(IEnumerable<IDiscount> discounts)
        => discounts.Where(d => d is not NoDiscount);

    private static IEnumerable<IDiscount> Flatten(IEnumerable<IDiscount> discounts)
    {
        foreach (var discount in discounts)
        {
            if (discount is CompositeDiscount composite)
            {
                foreach (var contained in composite.Discounts)
                {
                    yield return contained;
                }
            }
            else
            {
                yield return discount;
            }
        }
    }
}
