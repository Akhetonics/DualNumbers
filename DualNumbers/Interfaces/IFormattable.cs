namespace DualNumbers;

public readonly partial struct Dual : IFormattable
{
    public string ToString(string? format, IFormatProvider? formatProvider)
        => Helper.ToComplex(this).ToString(format, formatProvider);
}