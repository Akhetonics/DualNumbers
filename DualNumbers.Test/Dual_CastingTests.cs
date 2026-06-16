using System.Numerics;

namespace DualNumbers.Test;

[TestFixture]
public class DualCastingTests
{
	[Test]
	public void Implicit_FromSByteMinValue_SetsRealAndZeroDual()
	{
		sbyte value = sbyte.MinValue;
		Dual result = value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase((sbyte)-12)]
	[TestCase((sbyte)0)]
	[TestCase((sbyte)127)]
	public void Implicit_FromSByte_SetsRealAndZeroDual(sbyte value)
	{
		Dual result = value;

		Assert.That(result.real, Is.EqualTo(value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase((byte)0)]
	[TestCase((byte)200)]
	[TestCase(byte.MaxValue)]
	public void Implicit_FromByte_SetsRealAndZeroDual(byte value)
	{
		Dual result = value;

		Assert.That(result.real, Is.EqualTo(value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase((short)-32000)]
	[TestCase((short)0)]
	[TestCase(short.MaxValue)]
	public void Implicit_FromInt16_SetsRealAndZeroDual(short value)
	{
		Dual result = value;

		Assert.That(result.real, Is.EqualTo(value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[Test]
	public void Implicit_FromInt16MinValue_SetsRealAndZeroDual()
	{
		short value = short.MinValue;
		Dual result = value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase((ushort)0)]
	[TestCase((ushort)50000)]
	[TestCase(ushort.MaxValue)]
	public void Implicit_FromUInt16_SetsRealAndZeroDual(ushort value)
	{
		Dual result = value;

		Assert.That(result.real, Is.EqualTo(value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase(-123456789)]
	[TestCase(0)]
	[TestCase(int.MaxValue)]
	public void Implicit_FromInt32_SetsRealAndZeroDual(int value)
	{
		Dual result = value;

		Assert.That(result.real, Is.EqualTo(value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[Test]
	public void Implicit_FromInt32MinValue_SetsRealAndZeroDual()
	{
		int value = int.MinValue;
		Dual result = value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase((uint)0)]
	[TestCase((uint)4000000000)]
	[TestCase(uint.MaxValue)]
	public void Implicit_FromUInt32_SetsRealAndZeroDual(uint value)
	{
		Dual result = value;

		Assert.That(result.real, Is.EqualTo(value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase(-9007199254740991L)]
	[TestCase(0L)]
	[TestCase(long.MaxValue)]
	public void Implicit_FromInt64_SetsRealAndZeroDual(long value)
	{
		Dual result = value;

		Assert.That(result.real, Is.EqualTo(value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[Test]
	public void Implicit_FromInt64MinValue_SetsRealAndZeroDual()
	{
		long value = long.MinValue;
		Dual result = value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase(0UL)]
	[TestCase(9007199254740991UL)]
	[TestCase(ulong.MaxValue)]
	public void Implicit_FromUInt64_SetsRealAndZeroDual(ulong value)
	{
		Dual result = value;

		Assert.That(result.real, Is.EqualTo(value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase(-123.5f)]
	[TestCase(0f)]
	[TestCase(456.75f)]
	public void Implicit_FromSingle_SetsRealAndZeroDual(float value)
	{
		Dual result = value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase(float.PositiveInfinity)]
	[TestCase(float.NegativeInfinity)]
	public void Implicit_FromSingleInfinity_SetsRealAndZeroDual(float value)
	{
		Dual result = value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[Test]
	public void Implicit_FromSingleNaN_SetsRealNaNAndZeroDual()
	{
		float value = float.NaN;
		Dual result = value;

		Assert.That(result.real, Is.NaN);
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase(-123.5d)]
	[TestCase(0d)]
	[TestCase(456.75d)]
	public void Implicit_FromDouble_SetsRealAndZeroDual(double value)
	{
		Dual result = value;

		Assert.That(result.real, Is.EqualTo(value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase(double.PositiveInfinity)]
	[TestCase(double.NegativeInfinity)]
	public void Implicit_FromDoubleInfinity_SetsRealAndZeroDual(double value)
	{
		Dual result = value;

		Assert.That(result.real, Is.EqualTo(value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[Test]
	public void Implicit_FromDoubleNaN_SetsRealNaNAndZeroDual()
	{
		double value = double.NaN;
		Dual result = value;

		Assert.That(result.real, Is.NaN);
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase(-12.5f)]
	[TestCase(0f)]
	[TestCase(37.75f)]
	public void Implicit_FromHalf_SetsRealAndZeroDual(float rawValue)
	{
		Half value = (Half)rawValue;
		Dual result = value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase(float.PositiveInfinity)]
	[TestCase(float.NegativeInfinity)]
	public void Implicit_FromHalfInfinity_SetsRealAndZeroDual(float rawValue)
	{
		Half value = (Half)rawValue;
		Dual result = value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[Test]
	public void Implicit_FromHalfNaN_SetsRealNaNAndZeroDual()
	{
		Half value = Half.NaN;
		Dual result = value;

		Assert.That(result.real, Is.NaN);
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase('A')]
	[TestCase('0')]
	[TestCase('\u03A9')]
	public void Implicit_FromChar_SetsRealAndZeroDual(char value)
	{
		Dual result = value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase(-123456)]
	[TestCase(0)]
	[TestCase(987654)]
	public void Implicit_FromIntPtr_SetsRealAndZeroDual(int rawValue)
	{
		IntPtr value = rawValue;
		Dual result = value;

		Assert.That(result.real, Is.EqualTo((double)rawValue));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase(0u)]
	[TestCase(123456u)]
	[TestCase(987654u)]
	public void Implicit_FromUIntPtr_SetsRealAndZeroDual(uint rawValue)
	{
		UIntPtr value = rawValue;
		Dual result = value;

		Assert.That(result.real, Is.EqualTo((double)rawValue));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[Test]
	public void Explicit_FromInt128_SetsRealAndZeroDual()
	{
		Int128 value = (Int128)long.MaxValue + 123456789;
		Dual result = (Dual)value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase("170141183460469231731687303715884105727")]
	[TestCase("-170141183460469231731687303715884105728")]
	public void Explicit_FromInt128ExtremeValues_SetRealAndZeroDual(string valueText)
	{
		Int128 value = Int128.Parse(valueText);
		Dual result = (Dual)value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[Test]
	public void Explicit_FromUInt128_SetsRealAndZeroDual()
	{
		UInt128 value = (UInt128)ulong.MaxValue + 123456789;
		Dual result = (Dual)value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase("0")]
	[TestCase("340282366920938463463374607431768211455")]
	public void Explicit_FromUInt128ExtremeValues_SetRealAndZeroDual(string valueText)
	{
		UInt128 value = UInt128.Parse(valueText);
		Dual result = (Dual)value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[Test]
	public void Explicit_FromDecimal_SetsRealAndZeroDual()
	{
		decimal value = 1234567890.123456789m;
		Dual result = (Dual)value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase("79228162514264337593543950335")]
	[TestCase("-79228162514264337593543950335")]
	public void Explicit_FromDecimalExtremeValues_SetRealAndZeroDual(string valueText)
	{
		decimal value = decimal.Parse(valueText);
		Dual result = (Dual)value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[Test]
	public void Explicit_FromBigInteger_SetsRealAndZeroDual()
	{
		BigInteger value = BigInteger.Parse("123456789012345678901234567890");
		Dual result = (Dual)value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[TestCase("0")]
	[TestCase("-123456789012345678901234567890")]
	public void Explicit_FromBigIntegerBoundaryValues_SetRealAndZeroDual(string valueText)
	{
		BigInteger value = BigInteger.Parse(valueText);
		Dual result = (Dual)value;

		Assert.That(result.real, Is.EqualTo((double)value));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[Test]
	public void Explicit_FromComplex_MapsRealAndImaginaryToDualParts()
	{
		Complex value = new(2.5, -7.25);
		Dual result = (Dual)value;

		Assert.That(result.real, Is.EqualTo(value.Real));
		Assert.That(result.dual, Is.EqualTo(value.Imaginary));
	}
}
