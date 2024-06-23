using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public interface ILocalizable
{
    string Localize { get; }
    string Lcid { get; }
}
