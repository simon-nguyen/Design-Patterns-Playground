using Phowr.Core.Domain;
using Phowr.Core.Domain.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public class PhowrItem : MenuItemBase, ISellingItem, ILocalizable
{
    public string Name { get; private set; } = default!;

    public Money UnitPrice { get; private set; }

    public string Lcid { get; private set; } = "en";
    public string? Localize { get; private set; }

    public static PhowrItem Create(string name, Money unitPrice, string lcid = "en", string? localize = null)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
        if (unitPrice.IsLessThanZero() || unitPrice.IsZero()) throw new ArgumentException("Unit price must be greater than zero.");

        return new PhowrItem
        {
            Name = name,
            UnitPrice = unitPrice,
            Lcid = string.IsNullOrEmpty(lcid) ? "en" : lcid,
            Localize = string.IsNullOrEmpty(localize) ? name : localize
        };
    }
}
