namespace ConsoleGame.Classes;

public class LevelManager
{

  private static LevelManager instance;
  public static LevelManager GetInstance(int level)
  {
    instance ??= new LevelManager(level);
    return instance;
  }


  public int CurrentLevel { get; private set; }

  private LevelManager(int level)
  {
    CurrentLevel = level;
  }

}
