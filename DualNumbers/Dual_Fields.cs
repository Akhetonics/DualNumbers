using System.Net.Http.Headers;
using System.Numerics;

namespace DualNumbers;

public readonly partial struct Dual
{
    public static readonly Dual DualOne;
    public static readonly Dual Infinity;
    public static readonly Dual NaN;
    public static readonly Dual One;
    public static readonly Dual Zero;

    static Dual()
    {
        DualOne = new(0, 1);
        Infinity = new(double.PositiveInfinity, double.PositiveInfinity);
        NaN = new(double.NaN, double.NaN);
        One = new(1, 0);
        Zero = new(0, 0);
    }
}
