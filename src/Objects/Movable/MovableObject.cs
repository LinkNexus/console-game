namespace ConsoleGame.Classes.Objects.Movable;

public abstract class MovableObject : GameObject
{
  public event Action<Vector2> OnPositionChanged;
  public Vector2 PreviousPosition { get; private set; }

  protected MovableObject(Vector2 position, char symbol) : base(position, symbol) { }

  public void Move(Vector2 direction)
  {
    PreviousPosition = Position;
    Position += direction;
    OnPositionChanged?.Invoke(PreviousPosition);
    Draw();
  }

  public void RevertMove()
  {
    Position = PreviousPosition;
    Draw();
  }
}
