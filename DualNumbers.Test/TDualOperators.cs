using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualNumbers.Test
{
    
    public class TDualOperators
    {
        [TestFixture]
        public class TDualOperatorsTest
        {
            [TestCase(1.0, 2.0, 3.0, 4.0, 4.0, 6.0)]
            [TestCase(5.0,6.0, 10.0, 42.0, 15.0, 48.0 )]

            public void Addition (double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
            {
                // (5.0,6.0)
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


        [TestCase(3,1,5,1,15,8)]
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


        [TestCase(3, 1, 5, 1, 0.6, -0.08)]
        [TestCase(3, 0, 5, 0, 0.6, 0)]
        [TestCase(1, 2, 3, 4, 0.1, -0.08)]
        public void Division(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
        {
            // (a + bi) / (c + di) = 
            // (a + bi)*(c - di) / (c + di) * (c - di)
            // (ac - adi + bci - bdi^2) / ( c^2 + cdi - cdi - d^2i^2)
            // (ac - adi + bci - 0 ) / c^2 - 0 
            // (ac + i (bc - ad)/ c^2
            // (ac) + ((bc - ad) / c^2 ) * i


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
        }
    }

    

