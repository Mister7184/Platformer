using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] List<Enemy> _enemies;
    [SerializeField] CoinSpawner _coinSpawner;

    public void PlayGame() 
    {
        ActivateEnemies();
        _coinSpawner.Spawn();
    }

    private void ActivateEnemies() 
    {
        foreach (Enemy enemy in _enemies)
            enemy.Activate();
    }
}
