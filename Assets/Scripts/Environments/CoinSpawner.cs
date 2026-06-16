using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] List<Transform> _spawnPoints;
    [SerializeField] Coin _prefab;

    public void Spawn()
    {
        foreach (Transform point in _spawnPoints)
            Instantiate(_prefab, point.position, Quaternion.identity);
    }
}