using System;

namespace Phowr.Core.Domain;

/// <summary>
/// Represents the basic item of the store.
/// </summary>
public interface ISellingItem
{
    string Name { get; }
    Money UnitPrice { get; }
}
