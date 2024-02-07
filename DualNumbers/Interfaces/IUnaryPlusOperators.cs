namespace DualNumbers;

public readonly partial struct Dual : System.Numerics.IUnaryPlusOperators<Dual, Dual>
{
    public static Dual operator +(Dual a) => a;
}