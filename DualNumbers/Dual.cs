using System.Numerics;

namespace DualNumbers;

public readonly partial struct Dual(double realPart, double dualPart)
{
    public readonly double real = realPart;
    public readonly double dual = dualPart;

    // Overloaded operators below
    // Plus operator
    public static Dual operator +(Dual a, Double b) => new(a.real + b, a.dual);
    public static Dual operator +(Double a, Dual b) => new(a + b.real, b.dual);
    // Division operator
    public static Dual operator /(Dual a, Double b) => new(a.real / b, a.dual * b);
    public static Dual operator /(Double a, Dual b) => new(a / b.real, -a * b.dual);
    // Multiply operator
    public static Dual operator *(Dual a, Double b) => new(a.real * b, a.dual * b);
    public static Dual operator *(Double a, Dual b) => new(a * b.real, a * b.dual);
    // Subtraction operator
    public static Dual operator -(Dual a, Double b) => new(a.real - b, a.dual);
    public static Dual operator -(Double a, Dual b) => new(a - b.real, -b.dual);
    
    /*
    // Explicit operator
    [System.CLSCompliant(false)]
    public static explicit operator Dual(UInt128 value) => new((double)value, 0);
    [System.CLSCompliant(false)]
    public static explicit operator Dual(BigInteger value) => new((double)value, 0);
    [System.CLSCompliant(false)]
    public static explicit operator Dual(Decimal value) => new((double)value, 0);
    [System.CLSCompliant(false)]
    public static explicit operator Dual(Int128 value) => new((double)value, 0);

    // Implicit operator
    [System.CLSCompliant(false)]
    public static implicit operator Dual(sbyte value) => new(value, 0);
    [System.CLSCompliant(false)]
    public static implicit operator Dual(UIntPtr value) => new(value, 0);
    [System.CLSCompliant(false)]
    public static implicit operator Dual(UInt64 value) => new(value, 0);
    [System.CLSCompliant(false)]
    public static implicit operator Dual(UInt32 value) => new(value, 0);
    [System.CLSCompliant(false)]
    public static implicit operator Dual(UInt16 value) => new(value, 0);
    public static implicit operator Dual(Single value) => new((double)value, 0);
    public static implicit operator Dual(IntPtr value) => new(value, 0);
    public static implicit operator Dual(Double value) => new(value, 0);
    public static implicit operator Dual(Int32 value) => new(value, 0);
    public static implicit operator Dual(Int16 value) => new(value, 0);
    public static implicit operator Dual(Half value) => new((double)value, 0);
    public static implicit operator Dual(Int64 value) => new(value, 0);
    public static implicit operator Dual(Char value) => new(value, 0);
    public static implicit operator Dual(Byte value) => new(value, 0);
*/
}
