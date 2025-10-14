using ConsoleGame.Classes.Objects.Movable;

namespace ConsoleGame.Classes.Objects;

public class Player : MovableObject
{
  private int points;
  public int Points
  {
    set
    {
      if (points <= 0)
        points = 0;
      else points = value;
    }
    get => points;
  }

  public Player() : base(new(0, 0), '♕')
  {
  }
}
