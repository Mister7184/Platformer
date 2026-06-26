public class GameState : IGameState
{
    private GameContext _context;
    private GameStateMachine _stateMachine;

    private IGameState _gameOverState;

    public GameState(GameContext context, GameStateMachine stateMachine)
    {
        _context = context;
        _stateMachine = stateMachine;
    }

    public void Initialize(IGameState gameOverState) 
    {
        _gameOverState = gameOverState;
    }

    public void Enter()
    {
        _context.Player.Died += OnPlayerDied;
    }

    public void Update()
    {
        foreach(IUpdatable updatable in _context.Updatables)
            updatable.UpdateLogic();
    }

    public void FixedUpdate()
    {
        foreach (IFixedUpdatable fixedUpdatable in _context.FixedUpdatables)
            fixedUpdatable.FixedUpdateLogic();
    }

    public void Exit()
    {
        _context.Player.Died -= OnPlayerDied;
    }

    private void OnPlayerDied() 
    {
        _stateMachine.ChangeState(_gameOverState);
    }
}
