using System.Numerics;

namespace DualNumbers;

public readonly partial struct Dual : ISpanFormattable
{
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => Helper.ToComplex(this).TryFormat(destination, out charsWritten, format, provider);
}