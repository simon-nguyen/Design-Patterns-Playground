using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public interface IMenuVisitor
{
    void Visit(IMenuItem item);
}
