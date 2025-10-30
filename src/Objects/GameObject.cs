namespace ConsoleGame.Classes.Objects;

public abstract class GameObject(char symbol, Vector2 position)
{
  public char Symbol { get; } = symbol;
  public Vector2 Position { get; protected set; } = position;

  public virtual void Draw()
  {
    Console.SetCursorPosition(Position.X, Position.Y);
    Console.Write(Symbol);
  }
}
