using System.Numerics;

namespace DualNumbers;

//public readonly partial struct Dual(double realPart, double dualPart)
public readonly partial struct Dual(double realPart, double dualPart) : System.Numerics.INumberBase<Dual>
{
    public readonly double real = realPart;
    public readonly double dual = dualPart;
}
