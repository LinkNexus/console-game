namespace ConsoleGame.Classes.Objects;

public class Coin(Vector2 position, char symbol = '●', uint value = 10) :
  GameObject(symbol, position)
{

  public uint Value { get; private set; } = value;

}
