using ConsoleGame.Classes.Events;

namespace ConsoleGame.Classes.Objects;

public abstract class MovableObject : GameObject
{
  public event EventHandler<OnPositionChangedEventArgs> OnPositionChanged;
  public int Speed { get; set; }
  public Vector2 PreviousPosition { get; protected set; }

  public MovableObject(char appearance, Vector2 position, int speed = 1)
    : base(appearance, position)
  {
    PreviousPosition = position;
    Speed = speed;
    OnPositionChanged += (sender, args) =>
    {
      GameBoard.DrawAt(args.OldPosition, ' ');
    };
  }

  public void Move(Vector2 direction)
  {
    PreviousPosition = Position;
    Position += direction.ScalarMultiply(Speed);
    OnPositionChanged?.Invoke(this, new(PreviousPosition, Position));
    Draw();
  }

  public void RevertPosition()
  {
    (Position, PreviousPosition) = (PreviousPosition, Position);
    OnPositionChanged?.Invoke(this, new(PreviousPosition, Position));
    Draw();
  }

  public abstract void HandleCollision(GameObject other);

}
