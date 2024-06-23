using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public class InlinePhowrMenu : IMenu
{
    public IReadOnlyList<IMenuItem> Items => new List<PhowrItem>
    {
    };
}
