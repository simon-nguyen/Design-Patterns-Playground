using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain.Menu
{
    public abstract class MenuItemBase : IMenuItem
    {
        public virtual void Accept(IMenuVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
