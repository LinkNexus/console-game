namespace ConsoleGame;

using ConsoleGame.Classes;
using ConsoleGame.Classes.Objects;

class Program
{
  static void Main()
  {
    if (Console.WindowHeight < 30 || Console.WindowWidth < 100)
    {
      Console.WriteLine("Please resize your console window to at least 100x30 and restart the application.");
      Thread.Sleep(5000);
      return;
    }

    Console.CursorVisible = false;
    Console.Clear();

    var board = GameBoard.Instance;
    board.Draw();

    while (true)
    {
      if (Console.KeyAvailable)
      {
        var key = Console.ReadKey(true).Key;

        if (key == ConsoleKey.Escape)
        {
          Console.Clear();
          break;
        }

        board.MovePlayer(key);
      }
    }
  }

}
