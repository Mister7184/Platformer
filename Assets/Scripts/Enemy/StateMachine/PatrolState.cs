public class PatrolState : IEnemyState
{
    private EnemyContext _context;
    private EnemyStateMachine _stateMachine;

    private ChaseState _chaseState;

    public PatrolState(EnemyContext context, EnemyStateMachine stateMachine) 
    {
        _context = context;
        _stateMachine = stateMachine;
    }

    public void Initialize(ChaseState chaseState) 
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
