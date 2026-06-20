using UnityEngine;

[RequireComponent(typeof(Flipper), typeof(EnemyPatrol), typeof(EnemyVision))]
[RequireComponent(typeof(EnemyChaser), typeof(EnemyAttacker), typeof(CharacterAnimator))]

public class Enemy : MonoBehaviour
{
    private EnemyPatrol _patrol;
    private EnemyVision _vision;
    private EnemyAttacker _attacker;
    private EnemyChaser _chaser;
    private Flipper _flipper;
    private CharacterAnimator _animator;

    private EnemyStateMachine _stateMachine;

    private PatrolState _patrolState;
    private ChaseState _chaseState;
    private AttackState _attackState;

    private EnemyContext _context;

    public void Initialize(Transform player)
    {
        _flipper = GetComponent<Flipper>();
        _patrol = GetComponent<EnemyPatrol>();
        _vision = GetComponent<EnemyVision>();
        _attacker = GetComponent<EnemyAttacker>();
        _chaser = GetComponent<EnemyChaser>();
        _animator = GetComponent<CharacterAnimator>();

        _patrol.Initialize(_flipper);
        _vision.Initialize(_flipper);
        _chaser.Initialize(player, _flipper);
        _animator.Initialize();

        _context = new EnemyContext()
        {
            Player = player,
            Vision = _vision,
            Patrol = _patrol,
            Attacker = _attacker,
            Chaser = _chaser,
            Flipper = _flipper
        };

        _stateMachine = new EnemyStateMachine();

        _patrolState = new PatrolState(_context, _stateMachine);
        _chaseState = new ChaseState(_context, _stateMachine);
        _attackState = new AttackState(_context, _stateMachine);

        _patrolState.Initialize(_chaseState);
        _chaseState.Initialize(_patrolState, _attackState);
        _attackState.Initialize(_chaseState);

        _stateMachine.ChangeState(_patrolState);
    }

    public void UseUpdateLogic()
    {
        _stateMachine.Update();
    }
}