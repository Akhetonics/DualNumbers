using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace DualNumbers;

public readonly partial struct Dual : System.Numerics.ISignedNumber<Dual>
{
    public static Dual NegativeOne => new(-1, 0);
}