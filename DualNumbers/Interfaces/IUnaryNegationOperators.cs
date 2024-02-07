namespace DualNumbers;

public readonly partial struct Dual : System.Numerics.IUnaryNegationOperators<Dual, Dual>
{
    public static Dual operator -(Dual a) => new(-a.real, -a.dual);
}