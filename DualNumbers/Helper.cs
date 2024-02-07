using System.Text;

namespace DualNumbers;

public static class Helper
{
    public static Span<char> ConvertFromUtf8Bytes(ReadOnlySpan<byte> byteSpan)
    {
        string decodedString = Encoding.UTF8.GetString(byteSpan);
        char[] chars = new char[decodedString.Length];
        decodedString.AsSpan().CopyTo(chars);
        return new Span<char>(chars);
    }
}