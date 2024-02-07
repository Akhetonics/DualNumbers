namespace DualNumbers;

public readonly partial struct Dual : System.Numerics.IAdditiveIdentity<Dual, Dual>
{
    public static Dual AdditiveIdentity => Zero;
}