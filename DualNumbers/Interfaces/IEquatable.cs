namespace DualNumbers;

public readonly partial struct Dual : IEquatable<Dual>
{
    public override bool Equals(object? obj) { return obj is Dual other && real == other.real && dual == other.dual; }

    public bool Equals(Dual other) { return real == other.real && dual == other.dual; }

    public override int GetHashCode() { return System.HashCode.Combine(real, dual); }
}