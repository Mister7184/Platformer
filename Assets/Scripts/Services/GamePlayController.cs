using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private CoinSpawner _coinSpawner;

    public void Initialize(Transform player) 
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Initialize(player);
        }
        _coinSpawner.Spawn();
    }

    public void UseUpdateLogic() 
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.UseUpdateLogic();
        }
    }
}
