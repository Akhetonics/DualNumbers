using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace DualNumbers;

public readonly partial struct Dual : IParsable<Dual>
{
    public static Dual Parse(string s, IFormatProvider? provider) => Helper.ToDual(Complex.Parse(s, provider));

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Dual result)
    {
        bool tmp = Complex.TryParse(s, provider, out Complex complex);
        result = new(complex.Real, complex.Imaginary);
        return tmp;
    }
}