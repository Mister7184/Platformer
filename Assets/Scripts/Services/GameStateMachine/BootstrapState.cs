using UnityEngine;

public class BootstrapState : IGameState
{
    private GameStateMachine _stateMachine;
    private GameContext _context;
    private IGameState _gameState;

    public BootstrapState(GameStateMachine stateMachine, GameContext context)
    {
        _stateMachine = stateMachine;
        _context = context;
    }

    public void Initialize(IGameState gameState) 
    {
        _gameState = gameState;
    }

    public void Enter()
    {
        _context.Player.Initialize();
        Register(_context.Player);

        foreach (Enemy enemy in _context.Enemies)
        {
            enemy.Initialize(_context.Player.transform);
            Register(enemy);
        }

        foreach (ItemSpawner spawner in _context.Spawners)
        {
            spawner.Spawn();
        }

        _stateMachine.ChangeState(_gameState);
    }

    public void Update() 
    {

    }

    public void FixedUpdate() 
    {

    }

    public void Exit() 
    {

    }

    private void Register(Object obj)
    {
        if (obj is IUpdatable updatable)
            _context.Updatables.Add(updatable);

        if (obj is IFixedUpdatable fixedUpdatable)
            _context.FixedUpdatables.Add(fixedUpdatable);
    }
}
