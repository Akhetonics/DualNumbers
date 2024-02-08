namespace DualNumbers;

public readonly partial struct Dual : System.Numerics.IAdditionOperators<Dual, Dual, Dual>
{
    public static Dual operator +(Dual a, Dual b) => new(a.real + b.real, a.dual + b.dual);
}