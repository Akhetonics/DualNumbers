using System.Numerics;

namespace DualNumbers;

public readonly partial struct Dual
{    
    // Explicit operator
    public static explicit operator Dual(UInt128 value) => new((double)value, 0);
    public static explicit operator Dual(BigInteger value) => new((double)value, 0);
    public static explicit operator Dual(decimal value) => new((double)value, 0);
    public static explicit operator Dual(Int128 value) => new((double)value, 0);

    // Implicit operator
    public static implicit operator Dual(sbyte value) => new(value, 0);
    public static implicit operator Dual(UIntPtr value) => new(value, 0);
    public static implicit operator Dual(ulong value) => new(value, 0);
    public static implicit operator Dual(uint value) => new(value, 0);
    public static implicit operator Dual(ushort value) => new(value, 0);
    public static implicit operator Dual(float value) => new((double)value, 0);
    public static implicit operator Dual(IntPtr value) => new(value, 0);
    public static implicit operator Dual(double value) => new(value, 0);
    public static implicit operator Dual(int value) => new(value, 0);
    public static implicit operator Dual(short value) => new(value, 0);
    public static implicit operator Dual(Half value) => new((double)value, 0);
    public static implicit operator Dual(long value) => new(value, 0);
    public static implicit operator Dual(char value) => new(value, 0);
    public static implicit operator Dual(byte value) => new(value, 0);

    // hacky conversion :)
    public static explicit operator Dual(Complex value) => new(value.Real, value.Imaginary);
}
