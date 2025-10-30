using ConsoleGame.Classes.Objects;

if (Console.WindowHeight < 30 || Console.WindowWidth < 100)
{
  Console.WriteLine("Please resize your console window to at least 100x30 and restart the application.");
  Thread.Sleep(5000);
  return;
}

Console.CursorVisible = false;
Console.Clear();

GameBoard.Init();
