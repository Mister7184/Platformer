public class EnemyPatrolState : IEnemyState
{
    private EnemyContext _context;
    private EnemyStateMachine _stateMachine;

    private EnemyChaseState _chaseState;

    public EnemyPatrolState(EnemyContext context, EnemyStateMachine stateMachine) 
    {
        _context = context;
        _stateMachine = stateMachine;
    }

    public void Initialize(EnemyChaseState chaseState) 
    {
        _chaseState = chaseState;
    }

    public void Enter() 
    {

    }

    public void Update() 
    {
        _context.Patrol.UpdateLogic();

        if (_context.Vision.CanSeePlayer() || _context.Vision.CanHearPlayer())
            _stateMachine.ChangeState(_chaseState);
    }

    public void Exit()
    {
        
    }
}
