using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private List<ItemSpawner> _spawners;

    public void Initialize(Transform player) 
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Initialize(player);
        }

        foreach (var spawner in _spawners)
        {
            spawner.Spawn();
        }
    }

    public void UseUpdateLogic() 
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.UseUpdateLogic();
        }
    }
}
