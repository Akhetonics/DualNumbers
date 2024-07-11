using NUnit.Framework;
using System;
using DualNumbers;
using System.Numerics;
using System.Text.RegularExpressions;


namespace DualNumbers.Test;

public class TDualMethods : Attribute
{

    [TestFixture]
    public class DualTests
    {
        [Test]
        [TestCase(1.0, 2.0, 3.0, 4.0, 4.0, 6.0)]
        [TestCase(-1.0, 2.5, 3.1, -4.0, 2.1, -1.5)]
        [TestCase(0.0, 0.0, 0.0, 0.0, 0.0, 0.0)]
        public void Add_TwoDuals_ReturnsCorrectDual(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
        {
            var left = new DualNumbers.Dual(leftReal, leftDual);
            var right = new DualNumbers.Dual(rightReal, rightDual);
            var expected = new DualNumbers.Dual(expectedReal, expectedDual);

            var result = DualNumbers.Dual.Add(left, right);

            Assert.Multiple(() =>
            {

                //Standard testcases
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            });
            Assert.That(result.real, Is.Not.EqualTo(-1));
            Assert.That(result.dual, Is.Not.EqualTo(-1));


        }

        [TestCase(1.0, 2.0, 3.0, 4.0, 2.0)]
        [TestCase(-1.0, 2.5, 3.5, 2.5, 2.5)]
        [TestCase(0.0, 0.0, 1.0, 1.0, 0.0)]
        public void Add_DualAndDouble_ReturnsCorrectDual(double leftReal, double leftDual, double right, double expectedReal, double expectedDual)
        {
            var left = new Dual(leftReal, leftDual);
            var expected = new Dual(expectedReal, expectedDual);

            var result = Dual.Add(left, right);

            Assert.Multiple(() =>
            {
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            });
        }

        [TestCase(3.0, 1.0, 2.0, 4.0, 2.0)]
        [TestCase(3.5, -1.0, 2.5, 2.5, 2.5)]
        [TestCase(1.0, 0.0, 0.0, 1.0, 0.0)]
        public void Add_DoubleAndDual_ReturnsCorrectDual(double left, double rightReal, double rightDual, double expectedReal, double expectedDual)
        {
            var right = new Dual(rightReal, rightDual);
            var expected = new Dual(expectedReal, expectedDual);

            var result = Dual.Add(left, right);

            Assert.Multiple(() =>
            {
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            });
        }

        //public static Dual Acos(Dual value)
        // => new(Double.Acos(value.real), -value.dual / Math.Sqrt(1 - value.real * value.real));

        [Test]
        public void DualAcos()
        {
            // Arrange
            double realValue = 0.5;
            double dualValue = 0.2;
            Dual inputDual = new Dual(realValue, dualValue);

            // Erwartete Ergebnisse berechnen
            double expectedReal = Math.Acos(realValue);
            double expectedDual = -dualValue / Math.Sqrt(1 - realValue * realValue);

            Dual expectedDualResult = new Dual(expectedReal, expectedDual);

            // Act
            Dual result = Dual.Acos(inputDual);

            // Assert
            Assert.That(expectedDualResult.real, Is.EqualTo(result.real).Within(1e-10));
            Assert.That(expectedDualResult.dual, Is.EqualTo(result.dual).Within(1e-10));
        }

        [Test]
        public void DualAsin()
        {
            // Arrange
            double realValue = 0.5;
            double dualValue = 0.2; // Beispielwert für die duale Komponente
            Dual inputDual = new Dual(realValue, dualValue);

            // Erwartete Ergebnisse berechnen
            double expectedReal = Math.Asin(realValue);
            double expectedDual = dualValue / Math.Sqrt(1 - realValue * realValue);

            Dual expectedDualResult = new Dual(expectedReal, expectedDual);

            // Act
            Dual result = Dual.Asin(inputDual);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDualResult.real).Within(1e-10));
            Assert.That(result.dual, Is.EqualTo(expectedDualResult.dual).Within(1e-10));
        }

        [Test]
        public void TestAtan()
        {
            // Arrange
            double realValue = 0.5;
            double dualValue = 0.2; // Beispielwert für die duale Komponente
            Dual inputDual = new Dual(realValue, dualValue);

            // Erwartete Ergebnisse berechnen
            double expectedReal = Math.Atan(realValue);
            double expectedDual = dualValue / (1 + realValue * realValue);

            Dual expectedDualResult = new Dual(expectedReal, expectedDual);

            // Act
            Dual result = Dual.Atan(inputDual);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDualResult.real).Within(1e-10));
            Assert.That(result.dual, Is.EqualTo(expectedDualResult.dual).Within(1e-10));
        }

        [Test]
        public void TestConjugate()
        {
            // Arrange
            double realValue = 0.5;
            double dualValue = 0.2; // Beispielwert für die duale Komponente
            Dual inputDual = new Dual(realValue, dualValue);

            // Erwartete Ergebnisse berechnen
            double expectedReal = realValue;
            double expectedDual = -dualValue;

            Dual expectedDualResult = new Dual(expectedReal, expectedDual);

            // Act
            Dual result = Dual.Conjugate(inputDual);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDualResult.real).Within(1e-10));
            Assert.That(result.dual, Is.EqualTo(expectedDualResult.dual).Within(1e-10));
        }

        [Test]
        public void TestCos()
        {
            // Arrange
            double realValue = 0.5;
            double dualValue = 0.2; // Beispielwert für die duale Komponente
            Dual inputDual = new Dual(realValue, dualValue);

            // Erwartete Ergebnisse berechnen
            double expectedReal = Math.Cos(realValue);
            double expectedDual = -Math.Sin(realValue) * dualValue;

            Dual expectedDualResult = new Dual(expectedReal, expectedDual);

            // Act
            Dual result = Dual.Cos(inputDual);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDualResult.real).Within(1e-10));
            Assert.That(result.dual, Is.EqualTo(expectedDualResult.dual).Within(1e-10));
        }

        [Test]
        public void TestCosh()
        {
            // Arrange
            double realValue = 0.5;
            double dualValue = 0.2; // Beispielwert für die duale Komponente
            Dual inputDual = new Dual(realValue, dualValue);

            // Erwartete Ergebnisse berechnen
            double expectedReal = Math.Cosh(realValue);
            double expectedDual = dualValue * Math.Sinh(realValue);

            Dual expectedDualResult = new Dual(expectedReal, expectedDual);

            // Act
            Dual result = Dual.Cosh(inputDual);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDualResult.real).Within(1e-10));
            Assert.That(result.dual, Is.EqualTo(expectedDualResult.dual).Within(1e-10));
        }

        [Test]
        public void TestCreateChecked_Double()
        {
            // Arrange
            double inputValue = 3.14;
            Dual expectedDual = new Dual(inputValue, 0);

            // Act
            Dual result = Dual.CreateChecked<double>(inputValue);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDual.real).Within(1e-10));
            Assert.That(result.dual, Is.EqualTo(expectedDual.dual).Within(1e-10));
        }

        [Test]
        public void TestCreateChecked_Float()
        {
            // Arrange
            float inputValue = 2.718f;
            Dual expectedDual = new Dual(inputValue, 0);

            // Act
            Dual result = Dual.CreateChecked<float>(inputValue);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDual.real).Within(1e-6));
            Assert.That(result.dual, Is.EqualTo(expectedDual.dual).Within(1e-6));
        }

        [Test]
        public void TestCreateChecked_Int()
        {
            // Arrange
            int inputValue = 42;
            Dual expectedDual = new Dual(inputValue, 0);

            // Act
            Dual result = Dual.CreateChecked<int>(inputValue);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDual.real));
            Assert.That(result.dual, Is.EqualTo(expectedDual.dual));
        }

        [Test]
        public void TestCreateChecked_Complex()
        {
            // Arrange
            Complex inputValue = new Complex(1.0, 2.0);
            Dual expectedDual = new Dual(inputValue.Real, inputValue.Imaginary);

            // Act
            Dual result = Dual.CreateChecked<Complex>(inputValue);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDual.real).Within(1e-10));
            Assert.That(result.dual, Is.EqualTo(expectedDual.dual).Within(1e-10));
        }

        /*[Test]
         public void TestCreateChecked_NotSupported()
         {
             // Act & Assert
             NotSupportedException notSupportedException = Assert.Throws<NotSupportedException>(() => Dual.CreateChecked<object>("invalid"));
         }
        */

        [Test]
        public void TestCreateSaturating_Double()
        {
            // Arrange
            double inputValue = 1.5e100; // A value larger than double.MaxValue
            double expectedValue = double.MaxValue;
            Dual expectedDual = new Dual(expectedValue, 0);

            // Act
            Dual result = Dual.CreateSaturating<double>(inputValue);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDual.real));
            Assert.That(result.dual, Is.EqualTo(expectedDual.dual));
        }

        [Test]
        public void TestCreateSaturating_Float()
        {
            // Arrange
            float inputValue = 1.5e38f; // A value larger than float.MaxValue
            float expectedValue = float.MaxValue;
            Dual expectedDual = new Dual(expectedValue, 0);

            // Act
            Dual result = Dual.CreateSaturating<float>(inputValue);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDual.real));
            Assert.That(result.dual, Is.EqualTo(expectedDual.dual));
        }

        [Test]
        public void TestCreateSaturating_Int()
        {
            // Arrange
            int inputValue = 100;
            Dual expectedDual = new Dual(inputValue, 0);

            // Act
            Dual result = Dual.CreateSaturating<int>(inputValue);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDual.real));
            Assert.That(result.dual, Is.EqualTo(expectedDual.dual));
        }

        [Test]
        public void TestCreateSaturating_Complex()
        {
            // Arrange
            Complex inputValue = new Complex(1.5e100, -2.0); // A value larger than double.MaxValue
            double expectedReal = double.MaxValue;
            double expectedImaginary = -2.0;
            Dual expectedDual = new DualNumbers.Dual(expectedReal, expectedImaginary);

            // Act
            Dual result = Dual.CreateSaturating<Complex>(inputValue);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDual.real));
            Assert.That(result.dual, Is.EqualTo(expectedDual.dual));
        }

        /*[Test]
        public void TestCreateSaturating_NotSupported()
        {
            // Act & Assert
            Assert.Throws<NotSupportedException>(() => Dual.CreateSaturating<string>("invalid"));
        }*/

        [Test]
        public void TestCreateTruncating_Double()
        {
            // Arrange
            double inputValue = 3.9;
            int expectedValue = 3; // Truncate to integer part
            Dual expectedDual = new Dual(expectedValue, 0);

            // Act
            Dual result = Dual.CreateTruncating<double>(inputValue);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDual.real));
            Assert.That(result.dual, Is.EqualTo(expectedDual.dual));
        }

        [Test]
        public void TestCreateTruncating_Float()
        {
            // Arrange
            float inputValue = 5.6f;
            int expectedValue = 5; // Truncate to integer part
            Dual expectedDual = new Dual(expectedValue, 0);

            // Act
            Dual result = Dual.CreateTruncating<float>(inputValue);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDual.real));
            Assert.That(result.dual, Is.EqualTo(expectedDual.dual));
        }

        [Test]
        public void TestCreateTruncating_Int()
        {
            // Arrange
            int inputValue = 10;
            Dual expectedDual = new Dual(inputValue, 0);

            // Act
            Dual result = Dual.CreateTruncating<int>(inputValue);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDual.real));
            Assert.That(result.dual, Is.EqualTo(expectedDual.dual));
        }

        [Test]
        public void TestCreateTruncating_Complex()
        {
            // Arrange
            Complex inputValue = new Complex(3.9, 2.5);
            int expectedReal = 3; // Truncate to integer part
            int expectedImaginary = 2; // Truncate to integer part
            Dual expectedDual = new Dual(expectedReal, expectedImaginary);

            // Act
            Dual result = Dual.CreateTruncating<Complex>(inputValue);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedDual.real));
            Assert.That(result.dual, Is.EqualTo(expectedDual.dual));
        }

        /*[Test]
        public void TestCreateTruncating_NotSupported()
        {
            // Act & Assert
            Assert.Throws<NotSupportedException>(() => Dual.CreateTruncating<string>("invalid"));
        }*/

        [Test]
        public void TestDivide_DualByDual()
        {
            // Arrange
            var left = new Dual(6.0, 2.0);
            var right = new Dual(3.0, 1.0);
            var expected = new Dual(2.0, (2.0 * 3.0 - 6.0 * 1.0) / (3.0 * 3.0));

            // Act
            var result = Dual.Divide(left, right);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real));
            Assert.That(result.dual, Is.EqualTo(expected.dual));
        }

        [Test]
        public void TestDivide_DualByDouble()
        {
            // Arrange
            var left = new Dual(6.0, 2.0);
            double right = 2.0;
            var expected = new Dual(3.0, 1.0);

            // Act
            var result = Dual.Divide(left, right);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real));
            Assert.That(result.dual, Is.EqualTo(expected.dual));
        }

        [Test]
        public void TestDivide_DoubleByDual()
        {
            // Arrange
            double left = 6.0;
            var right = new Dual(3.0, 1.0);
            var expected = new Dual(2.0, -6.0 / (3.0 * 3.0));

            // Act
            var result = Dual.Divide(left, right);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real));
            Assert.That(result.dual, Is.EqualTo(expected.dual));
        }

        [Test]
        public void TestExp()
        {
            // Arrange
            var value = new Dual(2.0, 1.0); // Represents e^(2 + 1ε)
            var expected = new Dual(Math.Exp(2.0), Math.Exp(2.0) * 1.0); // Expected result

            // Act
            var result = Dual.Exp(value);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expected.dual).Within(1e-9));
        }

        /* [Test]
         public void TestFromPolarCoordinates()
         {
             // Arrange
             double magnitude = 2.0;
             double phase = Math.PI / 4.0; // 45 degrees
             var complexValue = Complex.FromPolarCoordinates(magnitude, phase);
             var expected = DualNumbers.Helper.ToDual(complexValue);

             // Act
             var result = Dual.FromPolarCoordinates(magnitude, phase);

             // Assert
             Assert.That(result.real, Is.EqualTo(expected.real).Within(1e-9));
             Assert.That(result.dual, Is.EqualTo(expected.dual).Within(1e-9));
         }*/

        [Test]
        public void TestLog()
        {
            // Test for Log(Dual value)
            // Arrange
            var value1 = new Dual(2.0, 1.0); // Represents log(2.0 + 1.0ε)
            var expectedLog1 = new Dual(Math.Log(2.0), 1.0 / 2.0); // Expected result

            // Act
            var resultLog1 = Dual.Log(value1);

            // Assert
            Assert.That(resultLog1.real, Is.EqualTo(expectedLog1.real).Within(1e-9));
            Assert.That(resultLog1.dual, Is.EqualTo(expectedLog1.dual).Within(1e-9));

            // Test for Log(Dual value, double baseValue)
            // Arrange
            var value2 = new Dual(2.0, 1.0); // Represents log base 10 (2.0 + 1.0ε)
            double baseValue = 10.0;
            var expectedLog2 = new Dual(Math.Log(2.0, baseValue), 1.0 / (2.0 * Math.Log(baseValue))); // Expected result

            // Act
            var resultLog2 = Dual.Log(value2, baseValue);

            // Assert
            Assert.That(resultLog2.real, Is.EqualTo(expectedLog2.real).Within(1e-9));
            Assert.That(resultLog2.dual, Is.EqualTo(expectedLog2.dual).Within(1e-9));
        }
        [Test]
        public void TestLog10()
        {
            // Test for Log10(Dual value)
            // Arrange
            var value3 = new Dual(2.0, 1.0); // Represents log base 10 (2.0 + 1.0ε)
            var expectedLog10 = new Dual(Math.Log10(2.0), 1.0 / (2.0 * Math.Log(10))); // Expected result

            // Act
            var resultLog10 = Dual.Log10(value3);

            // Assert
            Assert.That(resultLog10.real, Is.EqualTo(expectedLog10.real).Within(1e-9));
            Assert.That(resultLog10.dual, Is.EqualTo(expectedLog10.dual).Within(1e-9));
        }

        [Test]
        public void TestMultiplyDualDual()
        {
            // Test for Multiply(Dual left, Dual right)
            // Arrange
            var left = new Dual(2.0, 1.0);
            var right = new Dual(3.0, 2.0);
            var expected = new Dual(6.0, 7.0); // Expected result

            // Act
            var result = Dual.Multiply(left, right);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expected.dual).Within(1e-9));
        }

        [Test]
        public void TestMultiplyDualDouble()
        {
            // Test for Multiply(Dual left, Double right)
            // Arrange
            var left = new Dual(2.0, 1.0);
            double right = 3.0;
            var expected = new Dual(6.0, 3.0); // Expected result

            // Act
            var result = Dual.Multiply(left, right);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expected.dual).Within(1e-9));
        }

        [Test]
        public void TestMultiplyDoubleDual()
        {
            // Test for Multiply(Double left, Dual right)
            // Arrange
            double left = 2.0;
            var right = new Dual(3.0, 1.0);
            var expected = new Dual(6.0, 2.0); // Expected result

            // Act
            var result = Dual.Multiply(left, right);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expected.dual).Within(1e-9));
        }

        [Test]
        public void TestNegate()
        {
            // Test for Negate(Dual value)
            // Arrange
            var value = new Dual(2.0, -3.0); // Creating a Dual number (2.0 + (-3.0)ε)
            var expected = new Dual(-2.0, 3.0); // Expected result of negation

            // Act
            var result = Dual.Negate(value);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expected.dual).Within(1e-9));
        }

        [Test]
        public void TestPow_DoublePower()
        {
            // Test for Pow(Dual value, double power)
            // Arrange
            var value = new Dual(2.0, -1.0); // Creating a Dual number (2.0 - ε)
            double power = 3.0;
            var expected = new Dual(Math.Pow(2.0, 3.0), 3.0 * Math.Pow(2.0, 2.0) * (-1.0)); // Expected result

            // Act
            var result = Dual.Pow(value, power);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expected.dual).Within(1e-9));
        }

        [Test]
        public void TestPow_DualPower()
        {
            // Test for Pow(Dual value, Dual power)
            // Arrange
            var value = new Dual(2.0, -1.0); // Creating a Dual number (2.0 - ε)
            var power = new Dual(3.0, 2.0); // Creating a Dual number (3.0 + 2.0ε)
            var expectedRealPart = Math.Pow(2.0, 3.0);
            var expectedDualPart = 2.0 * Math.Log(2.0) * Math.Pow(2.0, 3.0) + (-1.0) * 3.0 * Math.Pow(2.0, 2.0); // Expected dual part

            // Act
            var result = Dual.Pow(value, power);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedRealPart).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expectedDualPart).Within(1e-9));
        }

        [Test]
        public void TestReciprocal()
        {
            // Test for Reciprocal(Dual value)
            // Arrange
            var value = new Dual(2.0, -1.0); // Creating a Dual number (2.0 - ε)
            var expected = new Dual(1 / 2.0, -(-1.0) / (2.0 * 2.0)); // Expected reciprocal

            // Act
            var result = Dual.Reciprocal(value);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expected.dual).Within(1e-9));
        }
        [Test]
        public void TestSin()
        {
            // Test for Sin(Dual value)
            // Arrange
            var value = new Dual(Math.PI / 2, 1.0); // Creating a Dual number (π/2 + ε)
            var expected = new Dual(Math.Sin(Math.PI / 2), 1.0 * Math.Cos(Math.PI / 2)); // Expected sine value

            // Act
            var result = Dual.Sin(value);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expected.dual).Within(1e-9));
        }

        [Test]
        public void TestSinh()
        {
            // Test for Sinh(Dual value)
            // Arrange
            var value = new Dual(1.0, 2.0); // Creating a Dual number (1.0 + 2.0ε)
            var expected = new Dual(Math.Sinh(1.0), 2.0 * Math.Cosh(1.0)); // Expected hyperbolic sine value

            // Act
            var result = Dual.Sinh(value);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expected.dual).Within(1e-9));
        }

        [Test]
        public void TestSqrt()
        {
            // Test for Sqrt(Dual value)
            // Arrange
            var value = new Dual(4.0, 2.0); // Creating a Dual number (4.0 + 2.0ε)
            var expected = new Dual(Math.Sqrt(4.0), 2.0 / (2 * Math.Sqrt(4.0))); // Expected square root value

            // Act
            var result = Dual.Sqrt(value);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expected.dual).Within(1e-9));
        }

        [Test]
        public void TestSubtractDualDual()
        {
            // Arrange
            var left = new Dual(5.0, 2.0);
            var right = new Dual(2.0, 1.0);
            var expected = new Dual(5.0 - 2.0, 2.0 - 1.0);

            // Act
            var result = Dual.Subtract(left, right);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expected.dual).Within(1e-9));
        }

        [Test]
        public void TestSubtractDualDouble()
        {
            // Arrange
            var left = new Dual(5.0, 2.0);
            var right = 2.0;
            var expected = new Dual(5.0 - right, 2.0);

            // Act
            var result = Dual.Subtract(left, right);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expected.dual).Within(1e-9));
        }

        [Test]
        public void TestSubtractDoubleDual()
        {
            // Arrange
            var left = 5.0;
            var right = new Dual(2.0, 1.0);
            var expected = new Dual(left - right.real, -right.dual);

            // Act
            var result = Dual.Subtract(left, right);

            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expected.dual).Within(1e-9));
        }

        [Test]
        public void TestTan()
        {
            // Arrange
            var value = new Dual(0.5, 1.0);
            var expectedReal = Math.Tan(0.5);
            var expectedDual = 1.0 / (Math.Cos(0.5) * Math.Cos(0.5)); // d(tan(x))/dx = 1/cos^2(x)

            // Act
            var result = Dual.Tan(value);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedReal).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expectedDual).Within(1e-9));
        }

        [Test]
        public void TestTanh()
        {
            // Arrange
            var value = new Dual(0.5, 1.0);
            var expectedReal = Math.Tanh(0.5);
            var expectedDual = 1.0 * (1 - Math.Pow(Math.Tanh(0.5), 2)); // d(tanh(x))/dx = 1 - tanh^2(x)

            // Act
            var result = Dual.Tanh(value);

            // Assert
            Assert.That(result.real, Is.EqualTo(expectedReal).Within(1e-9));
            Assert.That(result.dual, Is.EqualTo(expectedDual).Within(1e-9));
        }

        [Test]
        public void TestToStringWithFormat()
        {
            // Arrange
            var value = new Dual(1.23456789, 9.87654321);
            var expected = new Complex(1.23456789, 9.87654321).ToString("F2"); // Format: "F2"

            // Act
            var result = value.ToString("F2");

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestToStringWithProvider()
        {
            // Arrange
            var value = new Dual(1.23456789, 9.87654321);
            var cultureInfo = new System.Globalization.CultureInfo("fr-FR");
            var expected = new Complex(1.23456789, 9.87654321).ToString(cultureInfo);

            // Act
            var result = value.ToString(cultureInfo);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestToString()
        {
            // Arrange
            var value = new Dual(1.23456789, 9.87654321);
            var expected = new Complex(1.23456789, 9.87654321).ToString();

            // Act
            var result = value.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestTryFormat()
        {
            // Arrange
            var value = new Dual(1.23456789, 9.87654321);
            var utf8Destination = new Span<byte>(new byte[100]);
            int bytesWritten;
            var expectedComplex = new Complex(1.23456789, 9.87654321);
            var expectedBytesWritten = expectedComplex.ToString().Length;

            // Act
            bool result = value.TryFormat(utf8Destination, out bytesWritten);

            // Convert the actual output to string for comparison
            var actualOutput = System.Text.Encoding.UTF8.GetString(utf8Destination.Slice(0, bytesWritten));

            // Assert
            Assert.That(result,Is.True);
            Assert.That(bytesWritten, Is.EqualTo(expectedBytesWritten));
            Assert.That(actualOutput, Is.EqualTo(expectedComplex.ToString()));
        }


    }
}



