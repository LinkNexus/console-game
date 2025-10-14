namespace ConsoleGame.Classes.Objects;

public abstract class GameObject
{
  private Vector2 position;
  public Vector2 Position { get; set; }

  public char Appearance { get; }

  public GameObject(Vector2 position, char appearance)
  {
    Position = position;
    Appearance = appearance;
  }

  public virtual void Draw()
  {
    Console.SetCursorPosition(Position.X, Position.Y);
    Console.Write(Appearance);
  }
}
