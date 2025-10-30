namespace ConsoleGame.Classes;

public readonly struct ConsoleChar
{
  public string Symbol { get; }
  public int Width { get; }

  public ConsoleChar(string symbol)
  {
    if (string.IsNullOrEmpty(symbol))
      throw new ArgumentException("Symbol cannot be null or empty.", nameof(symbol));

    Symbol = symbol;
    Width = GetDisplayWidth(symbol);
  }

  private static int GetDisplayWidth(string s)
  {
    // Convert first character (handles surrogate pairs like emojis)
    int codePoint = char.ConvertToUtf32(s, 0);

    // Simplified width detection (covers most emojis + CJK characters)
    if (codePoint >= 0x1100 &&
        (codePoint <= 0x115F ||
         codePoint == 0x2329 || codePoint == 0x232A ||
         (codePoint >= 0x2E80 && codePoint <= 0xA4CF) ||
         (codePoint >= 0xAC00 && codePoint <= 0xD7A3) ||
         (codePoint >= 0xF900 && codePoint <= 0xFAFF) ||
         (codePoint >= 0xFE10 && codePoint <= 0xFE19) ||
         (codePoint >= 0xFE30 && codePoint <= 0xFE6F) ||
         (codePoint >= 0xFF00 && codePoint <= 0xFF60) ||
         (codePoint >= 0x1F000 && codePoint <= 0x1FAFF))) // emojis
    {
      return 2;
    }

    return 1;
  }

  public override string ToString() => Symbol;
}

