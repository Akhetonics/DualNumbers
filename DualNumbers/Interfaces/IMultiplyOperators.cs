namespace DualNumbers;

public readonly partial struct Dual : System.Numerics.IMultiplyOperators<Dual, Dual, Dual>
{
    public static Dual operator *(Dual a, Dual b) => new(a.real * b.real, a.real * b.dual + a.dual * b.real);
    
}