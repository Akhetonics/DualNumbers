using System.Numerics;
using System.Text;

namespace DualNumbers;
//internal static class Helper
public  static class Helper

{
    internal static Span<char> ConvertFromUtf8Bytes(ReadOnlySpan<byte> byteSpan)
    {
        string decodedString = Encoding.UTF8.GetString(byteSpan);
        char[] chars = new char[decodedString.Length];
        decodedString.AsSpan().CopyTo(chars);
        return new Span<char>(chars);
    }


    //internal static Dual ToDual(Complex value) => new(value.Real, value.Imaginary);
    public static Dual ToDual(Complex value) => new(value.Real, value.Imaginary);
    //internal static Complex ToComplex(Dual value) => new(value.real, value.dual);
    public static Complex ToComplex(Dual value) => new(value.real, value.dual);
}