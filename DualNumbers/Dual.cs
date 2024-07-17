using System.Numerics;

namespace DualNumbers;

public partial struct Dual(double realPart, double dualPart)

{
    public readonly double real = realPart;
    public readonly double dual = dualPart;
}
