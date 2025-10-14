using ConsoleGame.Classes.Objects.Movable;

namespace ConsoleGame.Classes.Objects;

public class Coin(Vector2 position) : GameObject(position, '●'), ICollidable
{
  private int Value;

  public void OnCollision(MovableObject movingObject)
  {
    switch (movingObject)
    {
      case Player player:
        player.Points += Value;
        break;
    }
  }
}
