using System.Collections.ObjectModel;
using ConsoleGame.Classes.Objects;

namespace ConsoleGame.Classes;

public class LevelManager
{

  public readonly ObservableCollection<GameObject> Objects = [];
  private static LevelManager instance;
  public static LevelManager Instance
  {
    get
    {
      if (instance == null)
      {
        throw new InvalidOperationException("LevelManager is not initialized. Call Init(level) first.");
      }
      return instance;
    }
  }

  public static void Init(int level)
  {
    instance = new LevelManager(level);
  }

  public int CurrentLevel { get; private set; }

  private LevelManager(int level)
  {
    CurrentLevel = level;
  }

  private void LoadLevel(int level)
  {
    switch (level)
    {
      case 1:
        LoadLevel1();
        break;
      // Add more levels as needed
      default:
        throw new ArgumentException($"Level {level} is not defined.");
    }
  }

  private void LoadLevel1()
  {
    Objects.Add(new Coin(new Vector2(10, 10)));
  }
}
