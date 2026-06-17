using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private CoinSpawner _coinSpawner;

    public void PlayGame() 
    {
        ActivateEnemies();
        _coinSpawner.Spawn();
    }

    private void ActivateEnemies() 
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Activate();
        }
    }
}
