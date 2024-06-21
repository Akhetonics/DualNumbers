using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DualNumbers.Test
{

    public class TDualOperators
    {
        [TestFixture]
        public class TDualOperatorsTest
        {
            [TestCase(1.0, 2.0, 3.0, 4.0, 4.0, 6.0)]
            [TestCase(5.0, 6.0, 10.0, 42.0, 15.0, 48.0)]

            public void Addition(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                //(5.0,6.0)
                var left = new Dual(leftReal, leftDual);
                //(10.0,42.0)               
                var right = new Dual(rightReal, rightDual);
                //(15.0,48.0)
                var expected = new Dual(expectedReal, expectedDual);

                var result = left + right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
                Assert.That(result.real, Is.Not.EqualTo(-1));
                Assert.That(result.dual, Is.Not.EqualTo(-1));
                Assert.That(result, Is.EqualTo(expected));
            }


            [TestCase(8.0, 8.0, 4.0, 4.0, 4.0, 4.0)]
            [TestCase(5.0, 6.0, 7.0, 42.0, -2.0, -36.0)]
            public void Substraction(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                //(1,2)(5,6) 
                var left = new Dual(leftReal, leftDual);
                //(3,4)(10,42)               
                var right = new Dual(rightReal, rightDual);
                //(4,6)(15,48)
                var expected = new Dual(expectedReal, expectedDual);

                var result = left - right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
                Assert.That(result.real, Is.Not.EqualTo(-1));
                Assert.That(result.dual, Is.Not.EqualTo(-1));
                Assert.That(result, Is.EqualTo(expected));
            }


            [TestCase(3, 1, 5, 1, 15, 8)]
            [TestCase(3, 0, 5, 0, 15, 0)]
            public void Multiplication(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                //(a*c) + i*(ad + bc)
                //(3*5) + i*((3*d) +(b*5))

                //(3,1)
                var left = new Dual(leftReal, leftDual);
                //(5,1)               
                var right = new Dual(rightReal, rightDual);
                //(15,8)
                var expected = new Dual(expectedReal, expectedDual);

                var result = left * right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
                Assert.That(result.real, Is.Not.EqualTo(-1));
                Assert.That(result.dual, Is.Not.EqualTo(-1));
                Assert.That(result, Is.EqualTo(expected));
            }


            [TestCase(3, 1, 5, 1, 0.6, 0.08)]
            [TestCase(3, 0, 5, 0, 0.6, 0)]
            [TestCase(6, 2, 3, 4, 2, -2)]
            public void Division(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                // (a + bi) / (c + di) = 

                // (a + bi)*(c - di) / (c + di) * (c - di)
                // (ac - adi + bci - bdi^2) / ( c^2 + cdi - cdi - d^2i^2)
                // (ac - adi + bci - 0 ) / c^2 - 0 
                // (ac + i (bc - ad) / c^2 =     

                // (a/c) + ((bc - ad) / c^2 ) * i


                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left / right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
                Assert.That(result.real, Is.Not.EqualTo(-1));
                Assert.That(result.dual, Is.Not.EqualTo(-1));
                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(0, 2, 0, 4)]
            public void DivisionByZero(double leftReal, double leftDual, double rightReal, double rightDual)
            {

                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var result = left / right;

                Assert.That(result.real, Is.NaN);
                Assert.That(result.dual, Is.NaN);

            }



            /*
             NaN:
             Vergleiche mit NaN:

             NaN == NaN ist immer false.
             NaN < anyNumber ist immer false.
             NaN > anyNumber ist immer false.
             NaN != anyNumber ist immer true.
             */

            //Entsteht durch undefinierte Operationen wie 0.0/0.0 oder sqrt(-1.0). Jede Operation mit NaN als Operand ergibt NaN (Spezialfall für Dualzahlen mit double)
            //Test failed hier, entweder falsch getestet oder Fehler in der Implementierung (evtl. weil +-* mit NaN nicht als default NaN implementiert ist?) 

            [TestCase(double.NaN, 0, 0, 0, double.NaN, 0)]
            [TestCase(0, double.NaN, 0, 0, 0, double.NaN)]
            [TestCase(0, 0, double.NaN, 0, double.NaN, 0)]
            [TestCase(0, 0, 0, double.NaN, 0, double.NaN)]
            public void AdditionWithNaN(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left + right;
                if (double.IsNaN(expected.real))
                {
                    Assert.That(result.real, Is.NaN);
                }
                else
                {
                    Assert.That(result.real, Is.EqualTo(expected.real));
                }

                if (double.IsNaN(expected.dual))
                {
                    Assert.That(result.dual, Is.NaN);
                }
                else
                {
                    Assert.That(result.dual, Is.EqualTo(expected.dual));
                }

            }

            [TestCase(double.NaN, 0,0, double.NaN, double.NaN, double.NaN)]

            public void SubtractionWithNaN(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left - right;

                Assert.That(result.real, Is.NaN);
                Assert.That(result.dual, Is.NaN);
            }

            [TestCase(double.NaN, 0, 0, double.NaN, double.NaN, double.NaN)]
            [TestCase(0, double.NaN, double.NaN, 0, double.NaN, double.NaN)]
            [TestCase(0, 0, double.NaN, double.NaN, double.NaN, double.NaN)]
            [TestCase(double.NaN, 0, 0, double.NaN, double.NaN, double.NaN)]
            public void MultiplicationWithNaN(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left * right;

                Assert.That(result.real, Is.NaN);
                Assert.That(result.dual, Is.NaN);
            }

            [TestCase(double.NaN, 0, 0, 0, double.NaN, double.NaN)]
            [TestCase(0, double.NaN, 0, 0, double.NaN, double.NaN)]
            [TestCase(0, 0, double.NaN, 0, double.NaN, double.NaN)]
            [TestCase(0, 0, 0, double.NaN, double.NaN, double.NaN)]
            public void DivisionWithNaN(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left / right;

                Assert.That(result.real, Is.NaN);
                Assert.That(result.dual, Is.NaN);
            }

            /* 

            INFINITY

            Addition und Subtraktion mit Unendlichkeit:

            Infinity + Infinity ergibt Infinity.
            Infinity - Infinity ergibt NaN.
            -Infinity + Infinity ergibt NaN.
            -Infinity - (-Infinity) ergibt NaN.

            Multiplikation mit Unendlichkeit:

            Infinity * 0.0 ergibt NaN.
            Infinity * Infinity ergibt Infinity.
            Infinity * (-Infinity) ergibt -Infinity.

            Division mit Unendlichkeit:

            Infinity / Infinity ergibt NaN.
            Infinity / 0.0 ergibt Infinity.
            0.0 / 0.0 ergibt NaN.
            0.0 / Infinity ergibt 0.0.

             */


            /*

            Addition mit Unendlichkeit

            //double.PositiveInfinity + 0 = double.PositiveInfinity
            //double.NegativeInfinity + 0 = double.NegativeInfinity

            */

            [TestCase(double.PositiveInfinity, 1, 0, 0, double.PositiveInfinity, 1)]
            [TestCase(1, double.PositiveInfinity, 0, 0, 1, double.PositiveInfinity)]
            [TestCase(1, 0, double.PositiveInfinity, 0, double.PositiveInfinity, 0)]
            [TestCase(1, 0, 0, double.PositiveInfinity, 1, double.PositiveInfinity)]
            public void AdditionWithInfinity(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left + right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            /*

            Subtraktion mit Unendlichkeit

            double.PositiveInfinity - 0 = double.PositiveInfinity
            double.NegativeInfinity - 0 = double.NegativeInfinity

            */

           
            [TestCase(double.PositiveInfinity, double.NegativeInfinity, 0, 0, double.PositiveInfinity, double.NegativeInfinity)]
            
            
            public void SubstractionWithInfinity(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left - right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }


            /*

            Multiplikation mit Unendlichkeit

            double.PositiveInfinity* 0 = double.NaN
            double.NegativeInfinity* 0 = double.NaN

            */

            [TestCase(double.PositiveInfinity, double.PositiveInfinity, 0, 0, double.NaN, double.NaN)]
            [TestCase(1, double.PositiveInfinity, double.PositiveInfinity, 1, double.PositiveInfinity,double.PositiveInfinity)]
            [TestCase(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity)]
            [TestCase(double.NaN, double.NaN,  double.PositiveInfinity, double.PositiveInfinity, double.NaN, double.NaN)]

            [TestCase(double.NegativeInfinity, double.NegativeInfinity, 0, 0, double.NaN, double.NaN)]
            [TestCase(1, double.NegativeInfinity, double.NegativeInfinity, 1, double.NegativeInfinity, double.PositiveInfinity)]
            [TestCase(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.PositiveInfinity, double.PositiveInfinity)]
            [TestCase(double.NaN, double.NaN, double.NegativeInfinity, double.NegativeInfinity, double.NaN, double.NaN)]

            public void MultiplicationWithInfinity(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left * right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }


            /*

            Division mit Unendlichkeit

            //double.PositiveInfinity / 0 = double.PositiveInfinity
            //double.NegativeInfinity / 0 = double.NegativeInfinity

            */
            [TestCase(double.PositiveInfinity, 1.0, 0.0, 1.0, /*double.PositiveInfinity*/double.PositiveInfinity, double.PositiveInfinity)]
            [TestCase(double.NegativeInfinity, 1.0, 0.0, 1.0, double.NegativeInfinity, double.NaN)]
            public void DivisionWithInfinity(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left / right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }


            /*

            Negative Null

             Unterscheidet sich von 0.0 und kann unterschiedliche Ergebnisse in bestimmten Berechnungen liefern, insbesondere bei Divisionen.
             Beispiel: 1.0/-0.0 ergibt -Infinity, während 1.0/0.0 Infinity ergibt.

            0 + (-0.0) = 0.0
            0 - (-0.0) = 0.0
            0 * (-0.0) = -0.0
            0 / (-0.0) = double.NegativeInfinity
            -0.0 / 0 = double.NegativeInfinity

            */

            [TestCase(0, 0, -0.0, 0, 0.0, 0)]
            [TestCase(0, -0.0, 0, 0, 0.0, 0)]
            [TestCase(-0.0, 0, 0, 0, 0.0, 0)]
            [TestCase(0, 0, 0, -0.0, 0.0, 0)]
            public void AdditionWithNegativeZero(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left + right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            [Test]
            [TestCase(0, 0, -0.0, 0, 0.0, 0)]
            [TestCase(0, -0.0, 0, 0, 0.0, 0)]
            [TestCase(-0.0, 0, 0, 0, -0.0, 0)]
            [TestCase(0, 0, 0, -0.0, 0.0, 0)]
            public void SubtractionWithNegativeZero(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left - right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            [Test]
            [TestCase(0, 0, -0.0, 0, -0.0, 0)]
            [TestCase(0, -0.0, 0, 0, 0, 0)]
            [TestCase(-0.0, 0, 0, 0, -0.0, 0)]
            [TestCase(0, 0, 0, -0.0, 0, 0)]
            public void MultiplicationWithNegativeZero(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left * right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            //Fälle testen, die 0 / 0 sind
            [Test]
            [TestCase(0, 0, -0.0, 0, double.NegativeInfinity, 0)]
            [TestCase(0, -0.0, 0, 0, double.NegativeInfinity, 0)]
            [TestCase(-0.0, 0, 0, 0, -0.0, 0)]
            [TestCase(0, 0, 0, -0.0, 0, 0)]
            public void DivisionWithNegativeZero(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left / right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }


            /*
             Overflow und Underflow


                Overflow

                Bei einer Operation, deren Ergebnis größer ist als double.MaxValue, ergibt sich double.PositiveInfinity.
                Bei einer Operation, deren Ergebnis kleiner ist als -double.MaxValue, ergibt sich double.NegativeInfinity.

                Underflow

                Bei einer Operation, deren Ergebnis betragsmäßig kleiner ist als der kleinste positive darstellbare Wert (double.Epsilon), ergibt sich 0.


             */


            //falscher testcase, fehler wegen zu kleiner Zahl (Implementierung von double das: Console.Write(double.MaxValue + (double.MaxValue / 2)); funktioniert)
            [TestCase(double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.PositiveInfinity, double.PositiveInfinity)]
            [TestCase(-double.MaxValue, -double.MaxValue,-double.MaxValue, -double.MaxValue, double.NegativeInfinity, double.NegativeInfinity)]
            public void AdditionOverflow(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left + right;


                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            
            [TestCase(double.NegativeInfinity, double.NegativeInfinity, double.PositiveInfinity, double.MaxValue, double.NegativeInfinity, double.NegativeInfinity)]
            [TestCase(double.MaxValue, 1.0, double.MaxValue, 1.0, 0.0, 0.0)]
            public void SubtractionOverflow(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left - right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            //overflow bei dual und real  und  bei beidem
            [TestCase(double.MaxValue, 1.0, 2.0, 10, double.PositiveInfinity, double.PositiveInfinity)]
            [TestCase(double.MaxValue, 0, 2.0, 0, double.PositiveInfinity, 0)]
            [TestCase(-double.MaxValue, 1.0, 2.0, 1.0, double.NegativeInfinity, -double.MaxValue)]
            public void MultiplicationOverflow(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left * right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            /*
            //Realteil: a/c DualteiL: (b*c - a*d) / (c*c)
            [TestCase(double.MinValue, double.MinValue, double.MaxValue, double.MaxValue, double.NegativeInfinity, double.NegativeInfinity)]
            [TestCase(double.MaxValue, double.PositiveInfinity, double.MinValue, double.MaxValue, double.NegativeInfinity, double.PositiveInfinity)]
            public void DivisionUnderflow(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left / right;
                Console.WriteLine((2 * double.MaxValue) / (double.MaxValue * double.MaxValue));
                Console.WriteLine((-double.MaxValue * -double.MaxValue));
                Console.WriteLine((2 / double.PositiveInfinity));
                Console.WriteLine((2 * double.MaxValue / double.PositiveInfinity));
                Console.WriteLine(double.PositiveInfinity / 100);
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }
            */

            [TestCase(double.MinValue, double.MinValue, double.MaxValue, double.MaxValue, -1, double.NaN)]
            [TestCase(double.MaxValue, double.PositiveInfinity, double.MinValue, double.MaxValue, -1, double.NaN)]
            public void DivisionUnderflow(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left / right;
                Console.WriteLine((2 * double.MaxValue) / (double.MaxValue * double.MaxValue));
                Console.WriteLine((-double.MaxValue * -double.MaxValue));
                Console.WriteLine((2 / double.PositiveInfinity));
                Console.WriteLine((2 * double.MaxValue / double.PositiveInfinity));
                Console.WriteLine(double.PositiveInfinity / 100);
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }


            [TestCase(double.MinValue, 1.0, double.MaxValue, 1.0, double.NegativeInfinity, 0.0)]
            [TestCase(-double.MaxValue, 1.0, double.MaxValue, 1.0, double.NegativeInfinity, 0.0)]
            public void SubtractionUnderflow(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left - right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            //realteil:(a*c)  dualteil: (a*d)+(b*c)
            [TestCase(double.MinValue, 1, 10000, 1.0, double.NegativeInfinity, double.MinValue)]
            [TestCase(-double.MaxValue, 1, double.MaxValue,double.MaxValue, double.NegativeInfinity, double.NegativeInfinity)]
            public void MultiplicationUnderflow(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left * right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            [TestCase(-double.MaxValue, 1.0, -double.MaxValue, 1.0, -double.PositiveInfinity, 2.0)]
            [TestCase(double.MinValue, 1.0, double.MinValue, 1.0, double.NegativeInfinity, 2.0)]
            public void AdditionUnderflow(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                var left = new Dual(leftReal, leftDual);
                var right = new Dual(rightReal, rightDual);
                var expected = new Dual(expectedReal, expectedDual);

                var result = left + right;

                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

        }

    }
}





