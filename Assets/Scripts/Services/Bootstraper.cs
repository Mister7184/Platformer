using System.Collections.Generic;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private List<ItemSpawner> _spawners;

    private List<IUpdatable> _updatables = new List<IUpdatable>(); 
    private List<IFixedUpdatable> _fixedUpdatables = new List<IFixedUpdatable>();

    private GameContext _context;
    private GameStateMachine _stateMachine;
    private BootstrapState _bootstrapState;
    private GameState _gameState;
    private GameOverState _gameOverState;

    private void Awake()
    {
        _context = new GameContext()
        {
            Player = _player,
            Enemies = _enemies,
            Spawners = _spawners,
            Updatables = _updatables,
            FixedUpdatables = _fixedUpdatables
        };

        _stateMachine = new GameStateMachine();
        _bootstrapState = new BootstrapState(_stateMachine, _context);
        _gameState = new GameState(_context, _stateMachine);
        _gameOverState = new GameOverState();

        _bootstrapState.Initialize(_gameState);
        _gameState.Initialize(_gameOverState);

        _stateMachine.ChangeState(_bootstrapState);
    }

    private void Update()
    {
        _stateMachine?.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine?.FixedUpdate();
    }
}
