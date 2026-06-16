namespace DualNumbers;

public readonly partial struct Dual : System.Numerics.INumberBase<Dual>
{
    static Dual System.Numerics.INumberBase<Dual>.Abs(Dual value) => Abs(value);
}
