namespace DualNumbers.Test.Methods;

[TestFixture]
public class DualTranscendentalMethodsTests
{
    [TestCase(0.5, 2.0, 1.0471975511965979, -2.3094010767585034)]
    [TestCase(0.0, -3.0, 1.5707963267948966, 3.0)]
    public void Acos_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Acos(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(0.5, 2.0, 0.5235987755982989, 2.3094010767585034)]
    [TestCase(0.0, -3.0, 0.0, -3.0)]
    public void Asin_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Asin(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(0.5, 2.0, 0.4636476090008061, 1.6)]
    [TestCase(-1.0, 3.0, -0.7853981633974483, 1.5)]
    public void Atan_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Atan(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(0.3, 1.2, 0.955336489125606, -0.3546242479936074)]
    [TestCase(0.0, -2.0, 1.0, 0.0)]
    public void Cos_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Cos(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(0.3, 1.2, 1.0453385141288605, 0.36542435213657115)]
    [TestCase(0.0, -2.0, 1.0, 0.0)]
    public void Cosh_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Cosh(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(1.5, 2.0, 4.4816890703380645, 8.963378140676129)]
    [TestCase(0.0, -3.0, 1.0, -3.0)]
    public void Exp_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Exp(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(3.0, 1.5, 1.0986122886681098, 0.5)]
    [TestCase(1.0, -2.0, 0.0, -2.0)]
    public void Log_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Log(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(8.0, 2.0, 2.0, 3.0, 0.36067376022224085)]
    [TestCase(100.0, 5.0, 10.0, 2.0, 0.02171472409516259)]
    public void Log_WithBase_ReturnsExpected(double real, double dual, double baseValue, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Log(new Dual(real, dual), baseValue);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(100.0, 2.0, 2.0, 0.008685889638065037)]
    [TestCase(1000.0, -3.0, 3.0, -0.0013028834457097555)]
    public void Log10_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Log10(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(0.3, 1.2, 0.29552020666133955, 1.146403786950727)]
    [TestCase(0.0, -2.0, 0.0, -2.0)]
    public void Sin_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Sin(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(0.3, 1.2, 0.3045202934471426, 1.2544062169545454)]
    [TestCase(0.0, -2.0, 0.0, -2.0)]
    public void Sinh_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Sinh(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(9.0, 6.0, 3.0, 1.0)]
    [TestCase(4.0, -2.0, 2.0, -0.5)]
    public void Sqrt_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Sqrt(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(0.3, 1.2, 0.30933624960962325, 1.2)]
    [TestCase(0.0, -2.0, 0.0, -2.0)]
    public void Tan_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Tan(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(0.3, 1.2, 0.2913126124515909, 1.098164354191955)]
    [TestCase(0.0, -2.0, 0.0, -2.0)]
    public void Tanh_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Tanh(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }
}
