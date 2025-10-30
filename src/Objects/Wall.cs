namespace ConsoleGame.Classes.Objects;

public enum WallType
{
  Horizontal,
  Vertical
}

public class Wall(Vector2 position, WallType type = WallType.Horizontal)
  : GameObject(type == WallType.Vertical ? '|' : '-', position)
{
  public WallType Type { get; } = type;
}
