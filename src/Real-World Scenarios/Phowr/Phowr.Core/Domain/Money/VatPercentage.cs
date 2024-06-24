using System;
using System.Collections.Generic;
using System.Text;

namespace Phowr.Core.Domain;

public readonly record struct Tax(double Percent)
{
    public const double Min = 0.0d;

    public static Tax From(double percent)
    {
        if (percent < Min)
            throw new ArgumentOutOfRangeException("Tax value should be positive.");

        return new Tax(percent);
    }

    public override readonly string ToString()
        => Percent.ToString("{#0.00%}");
}

public readonly record struct Percentage(decimal Value)
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
