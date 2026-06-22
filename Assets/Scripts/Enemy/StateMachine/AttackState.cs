using UnityEngine;

public class AttackState : IEnemyState
{
    private EnemyContext _context;
    private EnemyStateMachine _stateMachine;

    private ChaseState _chaseState;

    private float _timer;
    private float _attackCooldown = 1f;

    public AttackState(EnemyContext context, EnemyStateMachine stateMachine)
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
        _timer = 0f;
    }

    public void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer > 0)
            return;

        if (_context.Attacker.HasTarget())
        {
            _context.Attacker.Attack();
            _timer = _attackCooldown;
        }
        else 
        {
            _stateMachine.ChangeState(_chaseState);
        }

    }

    public void Exit()
    {

    }
}