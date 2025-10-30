using System.Collections.ObjectModel;
using ConsoleGame.Classes.Events;

namespace ConsoleGame.Classes.Objects;

public class GameBoard
{
  bool isRunning = true;
  const int Width = 100;
  const int Height = 30;
  public readonly ObservableCollection<GameObject> Objects = [];
  public readonly Player player;

  public readonly List<GameObject> ObjectsToBeRemoved = [];

  private static GameBoard instance;
  public static GameBoard Instance
  {
    get
    {
      instance ??= new GameBoard();
      return instance;
    }
  }

  private GameBoard()
  {
    WatchObjectsCollection();
    LevelManager.Init(1);
    CreateBorders();
    player = new(new Vector2(Console.WindowWidth / 2, Console.WindowHeight / 2));
    Objects.Add(player);
    DrawStatusBar();

    Objects.Add(new Coin(new Vector2(5, 5)));

    SubscribeToStatusBarUpdates();
  }

  void WatchObjectsCollection()
  {
    Objects.CollectionChanged += (sender, e) =>
    {
      if (e.NewItems != null)
      {
        foreach (var newItem in e.NewItems)
        {

          if (newItem is GameObject gameObj)
          {
            gameObj.Draw();
          }

          if (newItem is MovableObject movable)
          {
            movable.OnPositionChanged += HandleCollision;
          }
        }

        if (e.OldItems is not null)
        {
          foreach (var oldItem in e.OldItems)
          {
            if (oldItem is GameObject gameObj)
            {
              DrawAt(gameObj.Position, ' ');
            }

            if (oldItem is MovableObject movable)
            {
              movable.OnPositionChanged -= HandleCollision;
            }
          }
        }
      }
    };
  }

  void SubscribeToStatusBarUpdates()
  {
    player.OnPointsChanged += (sender, points) =>
    {
      DrawStatusBar();
    };
  }

  void HandleCollision(object? sender, OnPositionChangedEventArgs args)
  {
    foreach (var obj in Objects)
    {
      if (obj.Position == args.NewPosition && sender is MovableObject movable && obj != movable)
      {
        movable.HandleCollision(obj);
      }
    }

    ObjectsToBeRemoved.ForEach(obj =>
    {
      if (obj is GameObject gameObj)
      {
        Objects.Remove(gameObj);
      }
    });
  }

  public static void Init()
  {
    foreach (var obj in Instance.Objects)
    {
      obj.Draw();
    }

    while (Instance.isRunning)
    {
      Instance.ListenControls();
    }

    Console.CancelKeyPress += (sender, e) =>
    {
      Stop();
    };
  }

  public void ListenControls()
  {
    if (Console.KeyAvailable)
    {
      var keyInfo = Console.ReadKey(true);

      MovePlayer(keyInfo.Key);

      if (keyInfo.Key == ConsoleKey.Escape)
      {
        Stop();
      }
    }

  }

  public void MovePlayer(ConsoleKey keyInfo)
  {
    if (keyInfo == ConsoleKey.UpArrow)
      player.Move(new Vector2(0, -1));
    else if (keyInfo == ConsoleKey.DownArrow)
      player.Move(new Vector2(0, 1));
    else if (keyInfo == ConsoleKey.LeftArrow)
      player.Move(new Vector2(-1, 0));
    else if (keyInfo == ConsoleKey.RightArrow)
      player.Move(new Vector2(1, 0));

  }

  public static void Stop()
  {
    Console.Clear();
    Console.CursorVisible = true;
    Console.WriteLine("\nGame exited. Goodbye!");
    Thread.Sleep(1000);
    Instance.isRunning = false;
  }

  private void CreateBorders()
  {
    for (int x = 0; x < Width; x++)
    {
      Objects.Add(new Wall(new Vector2(x, 0)));
      Objects.Add(new Wall(new(x, Height - 3)));
      Objects.Add(new Wall(new Vector2(x, Height - 1)));
    }

    for (int y = 0; y < Height; y++)
    {
      Objects.Add(new Wall(new Vector2(0, y), WallType.Vertical));
      Objects.Add(new Wall(new Vector2(Width - 1, y), WallType.Vertical));
    }
  }

  private void DrawStatusBar()
  {
    Console.SetCursorPosition(2, Height - 2);
    Console.Write($"Points: {player.Points}, ");
    Console.Write($"Level: {LevelManager.Instance.CurrentLevel}, ");
  }

  public static void DrawAt(Vector2 position, char symbol)
  {
    Console.SetCursorPosition(position.X, position.Y);
    Console.Write(symbol);
  }
}
