namespace ConsoleGame.Classes;

public class StatusBar
{

  public int LevelLabel { get; set; }

  public void Draw()
  {
    Console.SetCursorPosition(1, Console.WindowHeight - 1);
    Console.WriteLine("Hello");
  }

}
