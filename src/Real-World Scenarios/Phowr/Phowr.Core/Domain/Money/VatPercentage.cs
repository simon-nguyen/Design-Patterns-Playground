using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public record struct Tax(decimal Percent)
{
    public const decimal Min = 0.0m;

    public override readonly string ToString()
        => Percent.ToString("{#0.00%}");
}

public record struct Percentage(decimal Value)
{
    public const int Min = 0;
    public const int Max = 100;

    public static Percentage From(decimal value)
    {
        if (value < Min || value > Max)
            throw new ArgumentOutOfRangeException("Percentage value should be between 0 and 100.");

        return new(value);
    }

    public override readonly string ToString()
        => Value.ToString("{#0.00%}");
}
