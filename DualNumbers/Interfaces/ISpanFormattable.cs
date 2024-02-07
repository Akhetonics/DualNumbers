using System.Numerics;

namespace DualNumbers;

public readonly partial struct Dual : ISpanFormattable
{
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        Complex tmp = new(real, dual);
        bool result = tmp.TryFormat(destination, out charsWritten, format, provider);
        return result;
    }
}