using System.Collections.ObjectModel;

namespace ConsoleGame.Classes.Objects;

public class GameBoard
{
  private static GameBoard instance;
  public static GameBoard Instance => instance ??= new GameBoard();

  readonly Player player = new();
  readonly ObservableCollection<GameObject> objects = [];
  readonly StatusBar statusBar = new();

  private GameBoard()
  {
    CreateBorders();
    player.OnPositionChanged += ClearAt;
    objects.CollectionChanged += (sender, e) =>
    {
      if (e.NewItems != null)
      {
        foreach (GameObject item in e.NewItems)
          item.Draw();
      }
    };
  }

  public void Draw()
  {
    statusBar.Draw();
    foreach (var obj in objects)
      obj.Draw();
    player.Position = new(Console.WindowWidth / 2, Console.WindowHeight / 2);
    player.Draw();
  }

  void CreateBorders()
  {
    for (var i = 0; i < Console.WindowHeight; i++)
    {
      objects.Add(new Wall(new(0, i), WallOrientation.Vertical));
      objects.Add(new Wall(new(Console.WindowWidth - 1, i), WallOrientation.Vertical));
    }

    for (var i = 0; i < Console.WindowWidth; i++)
    {
      objects.Add(new Wall(new(i, 0), WallOrientation.Horizontal));
      objects.Add(
        new Wall(new(i, Console.WindowHeight - 1), WallOrientation.Horizontal)
      );
      objects.Add(new Wall(new(i, Console.WindowHeight - 3), WallOrientation.Horizontal));
    }
  }

  public void MovePlayer(ConsoleKey key)
  {
    player.Move(key switch
    {
      ConsoleKey.UpArrow => new(0, -1),
      ConsoleKey.DownArrow => new(0, 1),
      ConsoleKey.LeftArrow => new(-1, 0),
      ConsoleKey.RightArrow => new(1, 0),
      _ => new(0, 0)
    });

    HandleCollisions();
  }

  public static void ClearAt(Vector2 position)
  {
    Console.SetCursorPosition(position.X, position.Y);
    Console.Write(" ");
  }

  void HandleCollisions()
  {
    foreach (var obj in objects)
    {
      if (player.Position == obj.Position && obj is ICollidable collidable)
      {
        collidable.OnCollision(player);
      }
    }
  }
}
