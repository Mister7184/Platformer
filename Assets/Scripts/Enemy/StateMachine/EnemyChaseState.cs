public class EnemyChaseState : IEnemyState
{
    private EnemyContext _context;
    private EnemyStateMachine _stateMachine;

    private EnemyPatrolState _patrolState;
    private EnemyAttackState _attackState;

    public EnemyChaseState(EnemyContext context, EnemyStateMachine stateMachine)
    {
        _context = context;
        _stateMachine = stateMachine;
    }

    public void Initialize(EnemyPatrolState patrolState, EnemyAttackState attackState)
    {
        _patrolState = patrolState;
        _attackState = attackState;
    }

    public void Enter()
    {

    }

    public void Update()
    {
        _context.Chaser.UpdateLogic();

        if (_context.Vision.CanSeePlayer() == false || _context.Vision.CanHearPlayer() == false)
            _stateMachine.ChangeState(_patrolState);

        if (_context.Attacker.HasTarget())
            _stateMachine.ChangeState(_attackState);
    }

    public void Exit()
    {
        _context.Patrol.SetDirection(_context.Chaser.Direction);
    }
}