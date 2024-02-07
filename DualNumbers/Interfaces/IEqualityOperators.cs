namespace DualNumbers;

public readonly partial struct Dual : System.Numerics.IEqualityOperators<Dual,Dual,bool>
{
    public static bool operator ==(Dual a, Dual b) => a.real == b.real && a.dual == b.dual;
    public static bool operator !=(Dual a, Dual b) => a.real != b.real || a.dual != b.dual;
}