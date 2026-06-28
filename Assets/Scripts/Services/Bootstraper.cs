using System.Collections.Generic;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private List<ItemSpawner> _spawners;

    private List<IUpdatable> _updatables = new List<IUpdatable>(); 
    private List<IFixedUpdatable> _fixedUpdatables = new List<IFixedUpdatable>();

    private void Awake()
    {
        _player.Initialize();
        Register(_player);

        foreach (Enemy enemy in _enemies)
        {
            enemy.Initialize(_player.transform);
            Register(enemy);
        }

        foreach (ItemSpawner spawner in _spawners)
        {
            spawner.Spawn();
        }
    }

    private void Update()
    {
        foreach (IUpdatable updatable in _updatables)
            updatable.UpdateLogic();
    }

    private void FixedUpdate()
    {
        foreach (IFixedUpdatable fixedUpdatable in _fixedUpdatables)
            fixedUpdatable.FixedUpdateLogic();
    }

    private void Register(Object obj)
    {
        if (obj is IUpdatable updatable)
            _updatables.Add(updatable);

        if (obj is IFixedUpdatable fixedUpdatable)
            _fixedUpdatables.Add(fixedUpdatable);
    }
}
