using System.Collections.Generic;

public class GameContext
{
    public Player Player;
    public List<Enemy> Enemies;
    public List<ItemSpawner> Spawners;
    public List<IUpdatable> Updatables;
    public List<IFixedUpdatable> FixedUpdatables;
}
