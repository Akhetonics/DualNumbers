using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualNumbers.Test
{
    public class TDualOperatorOverloading
    {
        [TestFixture]
        public class TDualOperatorsTest
        {

            // Plus operator tests
            //Dual operator +(Dual a, Double b) => new(a.real + b, a.dual);
            //aReal//aDual//bDouble//expectedANewDual//expectedADual
            [TestCase(1, 2, 3, 4, 2)]
            [TestCase(2, 3, double.NaN, double.NaN, 3)]
            [TestCase(2,double.NaN,3,5, double.NaN)]
            [TestCase(double.PositiveInfinity,2, 3, double.PositiveInfinity,2)]
            [TestCase(2,double.PositiveInfinity,3,5, double.PositiveInfinity)]
            [TestCase(double.NegativeInfinity, 2, 3, double.NegativeInfinity, 2)]
            [TestCase(2, double.NegativeInfinity, 3, 5, double.NegativeInfinity)]
            [TestCase(double.MaxValue, 2, 3, double.MaxValue + 3, 2)]
            [TestCase(1, double.MaxValue, 3, 4, double.MaxValue)]
            [TestCase(double.MinValue, 2, 3, double.MinValue + 3, 2)]
            [TestCase(1, double.MinValue, 3, 4, double.MinValue)]
            [TestCase(double.Epsilon, 2, 3, double.Epsilon + 3, 2)]
            [TestCase(1, double.Epsilon, 3, 4, double.Epsilon)]
            [TestCase(0, 2, 3, 3, 2)]
            [TestCase(1, 0, 3, 4, 0)]
            public void Addition_DualAndDouble(double aReal, double aDual, double b, double expectedReal, double expectedDual)
            {
                var a = new Dual(aReal, aDual);
                var result = a + b;
                Assert.That(result.real, Is.EqualTo(expectedReal));
                Assert.That(result.dual, Is.EqualTo(expectedDual));
            }

            [TestCase(3, 2, 3, 5, 3)]
            [TestCase(2, 3, double.NaN, 5,double.NaN)]
            [TestCase(3,double.NaN, 5, double.NaN,5)]
            [TestCase(2,double.PositiveInfinity, 3, double.PositiveInfinity,3)]
            [TestCase(2,3, double.PositiveInfinity, 5, double.PositiveInfinity)]
            [TestCase(2,3,double.NegativeInfinity, 5,double.NegativeInfinity)]
            [TestCase(2, double.NegativeInfinity, 3, (double.NegativeInfinity + 2), 3)]
            [TestCase(2,double.MaxValue, 3, (double.MaxValue + 2),3)]
            [TestCase(1,3, double.MaxValue, 4, double.MaxValue + 3)]
            [TestCase(2,3,double.MinValue, 5,double.MinValue + 3)]
            [TestCase(1, double.MinValue, 3,(double.MinValue + 1), 3)]
            [TestCase(2,double.Epsilon, 3, 2, double.Epsilon + 3)]
            [TestCase(1,3, double.Epsilon, 4, double.Epsilon)]
            [TestCase(0, 2, 3, 2, 3)]
            [TestCase(1, 0, 3, 1, 3)]

            public void Addition_DoubleAndDual(double a, double bReal, double bDual, double expectedReal, double expectedDual)
            {
                var b = new Dual(bReal, bDual);
                var result = a + b;
                //Console.WriteLine(bReal+bDual == );
                Assert.That(result.real, Is.EqualTo(expectedReal));
                Assert.That(result.dual, Is.EqualTo(expectedDual));
            }

            // DivisionWithNaN
            [TestCase(double.NaN, 2, 2, double.NaN, 4)]
            [TestCase(4, double.NaN, 2, 2, double.NaN)]
            //DivisionUnderflow
            [TestCase(1e-308, 1e-308, 1.0, 1e-308, 1e-308)]
            //DivisionByZero
            [TestCase(4, 2, 0, double.PositiveInfinity, 0)]
            //DivisionWith1
            [TestCase(4, 2, 1, 4, 2)]
            //regular
            [TestCase(6, 3, 3, 2, 9)]
            [TestCase(10, 5, 2, 5, 10)]
            [TestCase(4, 2, 2, 2, 4)]
            
            public void Division_DualAndDouble(double aReal, double aDual, double b, double expectedReal, double expectedDual)
            {
                var a = new Dual(aReal, aDual);
                var result = a / b;
                Assert.That(result.real, Is.EqualTo(expectedReal));
                Assert.That(result.dual, Is.EqualTo(expectedDual));
            }

            

            [TestCase(double.NaN, 3.0, 3, double.NaN, double.NaN)]
            [TestCase(9, double.NaN, 3, double.NaN, -27)]
            [TestCase(1e-308, 1e-308, 1, 1, -1e-308)]
            [TestCase(4, 0, 0, double.PositiveInfinity, -0)]
            [TestCase(4, -0, 0, double.PositiveInfinity,0)]
            [TestCase(4, 1, 0, 4, 0)]
            [TestCase(6, 3, 3, 2, -18)]
            [TestCase(10, 2, 5, 5, -50)]
            public void Division_DoubleAndDual(double a, double bReal, double bDual, double expectedReal, double expectedDual)
            {
                var b = new Dual(bReal, bDual);
                var result = a / b;
                Assert.That(result.real, Is.EqualTo(expectedReal));
                Assert.That(result.dual, Is.EqualTo(expectedDual));
            }



            // Multiply operator tests
            [TestCase(4, 2, 2, 8, 4)]
            [TestCase(3, 3, 3, 9, 9)]
            public void Multiplication_DualAndDouble(double aReal, double aDual, double b, double expectedReal, double expectedDual)
            {
                var a = new Dual(aReal, aDual);
                var result = a * b;
                Assert.That(result.real, Is.EqualTo(expectedReal));
                Assert.That(result.dual, Is.EqualTo(expectedDual));
            }

            [TestCase(4, 2, 2, 8, 8)]
            [TestCase(3, 3, 3, 9, 9)]
            public void Multiplication_DoubleAndDual(double a, double bReal, double bDual, double expectedReal, double expectedDual)
            {
                var b = new Dual(bReal, bDual);
                var result = a * b;
                Assert.That(result.real, Is.EqualTo(expectedReal));
                Assert.That(result.dual, Is.EqualTo(expectedDual));
            }

            // Subtraction operator tests
            [TestCase(4, 2, 2, 2, 2)]
            [TestCase(3, 3, 1, 2, 3)]
            public void Subtraction_DualAndDouble(double aReal, double aDual, double b, double expectedReal, double expectedDual)
            {
                var a = new Dual(aReal, aDual);
                var result = a - b;
                Assert.That(result.real, Is.EqualTo(expectedReal));
                Assert.That(result.dual, Is.EqualTo(expectedDual));
            }

            [TestCase(4, 2, 2, 2, -2)]
            [TestCase(3, 3.0, 1, 0, -1)]
            public void Subtraction_DoubleAndDual(double a, double bReal, double bDual, double expectedReal, double expectedDual)
            {
                var b = new Dual(bReal, bDual);
                var result = a - b;
                Assert.That(result.real, Is.EqualTo(expectedReal));
                Assert.That(result.dual, Is.EqualTo(expectedDual));
            }
        }
    }

}
    
