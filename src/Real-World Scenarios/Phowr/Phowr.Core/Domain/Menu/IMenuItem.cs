using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public interface IMenuItem
{
    void Accept(IMenuVisitor visitor);
}
