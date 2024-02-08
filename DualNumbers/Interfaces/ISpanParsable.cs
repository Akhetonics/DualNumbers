

using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace DualNumbers;

public readonly partial struct Dual : ISpanParsable<Dual>
{
    public static Dual Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        => Helper.ToDual(Complex.Parse(s, provider));

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Dual result)
    {
        bool tmp = Complex.TryParse(s, provider, out Complex complex);
        result = new(complex.Real, complex.Imaginary);
        return tmp;
    }
}