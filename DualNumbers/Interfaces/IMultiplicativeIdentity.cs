namespace DualNumbers;

public readonly partial struct Dual : System.Numerics.IMultiplicativeIdentity<Dual, Dual>
{
    public static Dual MultiplicativeIdentity => One;
}