namespace DualNumbers;

public readonly partial struct Dual : System.Numerics.IDecrementOperators<Dual>
{
    public static Dual operator --(Dual a) => new(a.real - 1, a.dual);
}