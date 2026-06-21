using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private PickupItem _prefab;
    [SerializeField] private SpawnModes _spawnMode;
    [SerializeField] private int _randomSpawnCount = 3;


    public void Spawn()
    {
        List<Transform> points = GetSpawnPoints();

        foreach (Transform point in points)
            Instantiate(_prefab, point.position, Quaternion.identity);
    }

    private List<Transform> GetSpawnPoints() 
    {
        if(_spawnMode == SpawnModes.AllPoints)
            return _spawnPoints;

        return GetRandomPoints();
    }

    private List<Transform> GetRandomPoints() 
    {
        List<Transform> availablePoints = new List<Transform>(_spawnPoints);    
        List<Transform> result = new List<Transform>();

        for (int i = 0; i < _randomSpawnCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            result.Add(availablePoints[randomIndex]);
            availablePoints.RemoveAt(randomIndex);
        }

        return result;
    }
}