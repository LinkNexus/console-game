using ConsoleGame.Classes.Objects.Movable;

namespace ConsoleGame.Classes.Objects;

public enum WallOrientation
{
  Horizontal,
  Vertical
}

public class Wall : GameObject, ICollidable
{
  public WallOrientation WallOrientation { get; init; }

  public Wall(Vector2 position, WallOrientation orientation = WallOrientation.Vertical)
    : base(position, orientation == WallOrientation.Vertical ? '|' : '-')
  {
    WallOrientation = orientation;
  }

  public void OnCollision(MovableObject movingObject)
  {
    switch (movingObject)
    {
      case Player player:
        GameBoard.ClearAt(player.Position);
        player.RevertMove();
        Draw();
        break;
    }
  }
}
