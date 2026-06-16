using System.Numerics;

namespace DualNumbers;

public readonly partial struct Dual : ISignedNumber<Dual>
{
    public static Dual NegativeOne => new(-1, 0);
}