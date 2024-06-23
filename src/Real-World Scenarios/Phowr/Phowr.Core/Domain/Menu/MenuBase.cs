using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public abstract class MenuBase : List<IMenuItem>, IMenu
{
    public IReadOnlyList<IMenuItem> Items => this;
}
