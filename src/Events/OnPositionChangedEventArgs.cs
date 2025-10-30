namespace ConsoleGame.Classes.Events;

public class OnPositionChangedEventArgs(Vector2 oldPosition, Vector2 newPosition) : EventArgs
{
  public Vector2 OldPosition { get; } = oldPosition;
  public Vector2 NewPosition { get; } = newPosition;
}
