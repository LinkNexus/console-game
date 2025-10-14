namespace ConsoleGame.Classes;

public struct Vector2
{
  public int X { get; set; }

  public int Y { get; set; }

  public Vector2(int x, int y)
  {
    X = x;
    Y = y;
  }

  public readonly Vector2 Add(Vector2 other)
  {
    return new Vector2(X + other.X, Y + other.Y);
  }

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

  public override int GetHashCode()
  {
    return HashCode.Combine(X, Y);
  }

  public override bool Equals(object? obj)
  {
    if (obj is Vector2 other)
    {
      return X == other.X && Y == other.Y;
    }
    return false;
  }
}
