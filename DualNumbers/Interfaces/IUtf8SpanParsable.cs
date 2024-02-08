using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace DualNumbers;

public readonly partial struct Dual : IUtf8SpanParsable<Dual>
{

    public static Dual Parse(ReadOnlySpan<byte> utf8Text, IFormatProvider? provider)
    {
        Span<Char> s = Helper.ConvertFromUtf8Bytes(utf8Text);
        return Helper.ToDual(Complex.Parse(s, provider));
    }

    public static bool TryParse(ReadOnlySpan<byte> utf8Text, IFormatProvider? provider, [MaybeNullWhen(false)] out Dual result)
    {
        Span<Char> s = Helper.ConvertFromUtf8Bytes(utf8Text);
        bool tmp = Complex.TryParse(s, provider, out Complex complex);
        result = new(complex.Real, complex.Imaginary);
        return tmp;
    }
}