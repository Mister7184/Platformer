using UnityEngine;

[RequireComponent(typeof(Flipper), typeof(EnemyPatrol), typeof(EnemyVision))]
[RequireComponent(typeof(EnemyChaser), typeof(EnemyAttacker), typeof(Health))]

public class Enemy : MonoBehaviour
{
    private EnemyPatrol _patrol;
    private EnemyVision _vision;
    private EnemyAttacker _attacker;
    private EnemyChaser _chaser;
    private Flipper _flipper;
    private CharacterAnimator _animator;
    private Health _health;

    private EnemyStateMachine _stateMachine;

    private EnemyPatrolState _patrolState;
    private EnemyChaseState _chaseState;
    private EnemyAttackState _attackState;
    private EnemyHitState _hitState;
    private EnemyDieState _dieState;

    private EnemyContext _context;

    private void OnDisable()
    {
        _health.Damaged -= _animator.PlayTakeDamage;
        _health.Died -= _animator.PlayDie;
    }

    public void Initialize(Transform player)
    {
        _flipper = GetComponent<Flipper>();
        _patrol = GetComponent<EnemyPatrol>();
        _vision = GetComponent<EnemyVision>();
        _attacker = GetComponent<EnemyAttacker>();
        _chaser = GetComponent<EnemyChaser>();
        _health = GetComponent<Health>();
        _animator = GetComponentInChildren<CharacterAnimator>();

        _patrol.Initialize(_flipper, _animator);
        _vision.Initialize(_flipper);
        _chaser.Initialize(player, _flipper, _animator);
        _animator.Initialize();
        _attacker.Initialize(_animator);
        _health.Initialize();

        _health.Damaged += OnHit;
        Debug.Log("Подписал анимацию урона " + gameObject.name);
        _health.Died += OnDie;

        _context = new EnemyContext()
        {
            Player = player,
            Vision = _vision,
            Patrol = _patrol,
            Attacker = _attacker,
            Chaser = _chaser,
            Flipper = _flipper,
            Animator = _animator,
            Health = _health,
            Root = gameObject
        };

        _stateMachine = new EnemyStateMachine();

        _patrolState = new EnemyPatrolState(_context, _stateMachine);
        _chaseState = new EnemyChaseState(_context, _stateMachine);
        _attackState = new EnemyAttackState(_context, _stateMachine);
        _hitState = new EnemyHitState(_context, _stateMachine);
        _dieState = new EnemyDieState(_context, _stateMachine);

        _patrolState.Initialize(_chaseState);
        _chaseState.Initialize(_patrolState, _attackState);
        _attackState.Initialize(_chaseState);

        _stateMachine.ChangeState(_patrolState);
    }

    public void UseUpdateLogic()
    {
        _stateMachine.Update();
    }

    private void OnHit() 
    {
        _hitState.SetReturnState(_stateMachine.LastState);
        _stateMachine.ChangeState(_hitState);
    }

    private void OnDie() 
    {
        _stateMachine.ChangeState(_dieState);
    }
}