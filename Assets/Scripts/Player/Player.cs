using System;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(PlayerMover),  typeof(PlayerJumper))]
[RequireComponent(typeof(Flipper), typeof(Health), typeof(PlayerAttacker))]
[RequireComponent(typeof(PlayerCollector), typeof(PlayerWallet))]

public class Player : MonoBehaviour, IUpdatable, IFixedUpdatable
{
    private Rigidbody2D _rigidbody;
    private PlayerMover _mover;
    private CharacterAnimator _animator;
    private PlayerJumper _jumper;
    private PlayerInput _input;
    private Flipper _flipper;
    private Health _health;
    private PlayerAttacker _attacker;
    private PlayerCollector _collector;
    private PlayerWallet _wallet;
    private GroundChecker _groundChecker;

    private PlayerStateMachine _stateMachine;
    private PlayerContext _context;

    private PlayerIdleState _idleState;
    private PlayerMoveState _moveState;
    private PlayerJumpState _jumpState;
    private PlayerAttackState _attackState;
    private PlayerHitState _hitState;
    private PlayerDieState _dieState;

    public Action Died;

    private void OnDisable()
    {
        _health.Damaged -= _animator.PlayTakeDamage;
        _health.Died -= OnDie;
    }

    public void Initialize()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _flipper = GetComponent<Flipper>();
        _mover = GetComponent<PlayerMover>();
        _jumper = GetComponent<PlayerJumper>();
        _health = GetComponent<Health>();
        _attacker = GetComponent<PlayerAttacker>();
        _collector = GetComponent<PlayerCollector>();
        _wallet = GetComponent<PlayerWallet>();
        _animator = GetComponentInChildren<CharacterAnimator>();
        _groundChecker = GetComponentInChildren<GroundChecker>();

        _mover.Initialize(_rigidbody, _input, _flipper);
        _jumper.Initialze(_rigidbody);
        _health.Initialize();
        _animator.Initialize();
        _collector.Initialize(_wallet, _health);

        _mover.SpeedChanged += _animator.SetSpeed;
        _health.Damaged += OnHit;
        _health.Died += OnDie;

        _context = new PlayerContext()
        {
            Input = _input,
            Mover = _mover,
            Jumper = _jumper,
            Attacker = _attacker,
            Animator = _animator,
            Health = _health,
            GroundChecker = _groundChecker,
        };

        _stateMachine = new PlayerStateMachine();

        _idleState = new PlayerIdleState(_context, _stateMachine);
        _moveState = new PlayerMoveState(_context, _stateMachine);
        _jumpState = new PlayerJumpState(_context, _stateMachine);
        _attackState = new PlayerAttackState(_context, _stateMachine);
        _hitState = new PlayerHitState(_context, _stateMachine);
        _dieState = new PlayerDieState(_context);

        _idleState.Initialize(_moveState, _jumpState, _attackState);
        _moveState.Initialize(_idleState, _jumpState, _attackState);
        _jumpState.Initialize(_idleState, _moveState);
        _attackState.Initialize(_moveState, _idleState, _jumpState);
        _hitState.Initialize(_moveState, _idleState, _jumpState);

        _stateMachine.ChangeState(_idleState);
    }

    public void UpdateLogic() 
    {
        _input.UpdateLogic();
        _stateMachine.Update();
    }

    public void FixedUpdateLogic() 
    {
        _stateMachine.FixedUpdate();
    }

    private void OnHit() 
    {
        if(_stateMachine.Current == _dieState)
            return;

        _stateMachine.ChangeState(_hitState);
    }

    private void OnDie() 
    {
        Died?.Invoke();
        _stateMachine.ChangeState(_dieState);
    }
}