using System.Collections.ObjectModel;
using ConsoleGame.Classes.Objects;

namespace ConsoleGame.Classes;

public class LevelManager
{
  int level;
  readonly ObservableCollection<GameObject> objects = [];

  private LevelManager instance;
  public LevelManager Instance => instance ??= new LevelManager(1);

  private LevelManager(int level)
  {
    this.level = level;

    objects.CollectionChanged += (s, e) =>
    {
      if (e.NewItems != null)
        foreach (GameObject obj in e.NewItems)
          obj.Draw();
    };
  }

  public void LoadLevel(int level)
  {
    this.level = level;
    objects.Clear();
    switch (level)
    {
      case 1:
        LoadLevel1();
        break;
    }
  }

  void LoadLevel1()
  {
    objects.Add(new Coin(new(10, 10)));
  }

}
