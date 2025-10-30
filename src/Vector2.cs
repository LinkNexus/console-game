namespace ConsoleGame.Classes;

public struct Vector2(int x, int y)
{
  public int X { get; set; } = x;

  public int Y { get; set; } = y;

  public readonly Vector2 Add(Vector2 other)
  {
    return new Vector2(X + other.X, Y + other.Y);
  }

  public readonly Vector2 ScalarMultiply(int scalar) => new(X * scalar, Y * scalar);

  public static Vector2 operator +(Vector2 a, Vector2 b)
  {
    return a.Add(b);
  }

  public static bool operator ==(Vector2 a, Vector2 b)
  {
    return a.Equals(b);
  }

  public static bool operator !=(Vector2 a, Vector2 b)
  {
    return !(a == b);
  }

  public readonly override int GetHashCode()
  {
    return HashCode.Combine(X, Y);
  }

  public readonly override bool Equals(object? obj)
  {
    return obj is Vector2 other && X == other.X && Y == other.Y;
  }
}
