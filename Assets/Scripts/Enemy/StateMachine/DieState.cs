using UnityEngine;

public class DieState : IEnemyState
{
    private EnemyContext _context;
    private EnemyStateMachine _stateMachine;

    private float _dieDuration = 1f;
    private float _timer;

    public DieState(EnemyContext context, EnemyStateMachine stateMachine) 
    {
        _context = context;
        _stateMachine = stateMachine;
    }

    public void Enter() 
    {
        _timer = _dieDuration;

        _context.Animator.PlayDie();

        _stateMachine.Lock();

        _context.Patrol.enabled = false;
        _context.Chaser.enabled = false;
        _context.Attacker.enabled = false;
        _context.Vision.enabled = false;
    }

    public void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0f) 
        {
            Object.Destroy(_context.Root);
        }
    }

    public void Exit() 
    {

    }
}
