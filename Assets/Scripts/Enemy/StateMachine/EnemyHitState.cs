using UnityEngine;

public class EnemyHitState : IEnemyState
{
    private EnemyContext _context;
    private EnemyStateMachine _stateMachine;

    private IEnemyState _returnState;

    private float _hitDuration = 0.4f;
    private float _timer;

    public EnemyHitState(EnemyContext context, EnemyStateMachine stateMachine)
    {
        _context = context;
        _stateMachine = stateMachine;
    }

    public void SetReturnState(IEnemyState state)
    {
        _returnState = state;
    }

    public void Enter()
    {
        _timer = _hitDuration;

        _context.Animator.PlayTakeDamage();

        _context.Patrol.enabled = false;
        _context.Chaser.enabled = false;
        _context.Attacker.enabled = false;
    }

    public void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
            _stateMachine.ChangeState(_returnState);
    }

    public void Exit()
    {
        _context.Patrol.enabled = true;
        _context.Chaser.enabled = true;
        _context.Attacker.enabled = true;
    }
}
