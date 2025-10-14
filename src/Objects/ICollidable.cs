using ConsoleGame.Classes.Objects.Movable;

namespace ConsoleGame.Classes.Objects;

public interface ICollidable
{
  public void OnCollision(MovableObject movingObject);
}
