using ConsoleGame.Classes;
using ConsoleGame.Classes.Objects;

namespace ConsoleGame.Classes.Objects;

public class Player(Vector2 position, char symbol = '@') : MovableObject(symbol, position)
{
  public int Points { get; private set; } = 0;
  public event EventHandler<int> OnPointsChanged;

  public override void HandleCollision(GameObject other)
  {
    switch (other)
    {
      case Wall wall:
        RevertPosition();
        wall.Draw();
        break;
      case Coin coin:
        Points += (int)coin.Value;
        OnPointsChanged?.Invoke(this, Points);
        GameBoard.Instance.ObjectsToBeRemoved.Add(coin);
        break;
    }
  }

}
