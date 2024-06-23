using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Phowr.Core.Domain.ShoppingCart
{
    public class ShoppingCartItemBase(ISellingItem item, int quantity) : IShoppingCartItem
    {
        public ISellingItem Item => item;

        public int Quantity => quantity;

        public virtual void Accept(IShoppingCartVisitor visitor)
        {
            visitor.Visit(this);
        }

        public static IShoppingCartItem Create(ISellingItem item)
            => Create(item, 1);

        public static IShoppingCartItem Create(ISellingItem item, int quantity)
            => new ShoppingCartItemBase(item, quantity < 1 ? 1 : quantity);
    }
}
