using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phowr.Core.Domain.UnitTests.Pocos.Items
{
    public record Subscription(ISubscriptionKind Kind, ISubscriptionPeriod Period);

    public interface ISubscriptionKind { }

    public record Basic : ISubscriptionKind;
    public record Pro : ISubscriptionKind;
    public record Ultimate : ISubscriptionKind;

    public interface ISubscriptionPeriod { }

    public record Yearly : ISubscriptionPeriod;
    public record Monthly : ISubscriptionPeriod;
}
