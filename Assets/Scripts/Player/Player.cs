using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerMover), typeof(PlayerJumper))]
[RequireComponent(typeof(Health), typeof(PlayerAttacker), typeof(PlayerVision))]
[RequireComponent(typeof(PlayerCollector), typeof(PlayerWallet), typeof(VampirismAbility))]

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
    private PlayerVision _vision;
    private PlayerCollector _collector;
    private PlayerWallet _wallet;
    private GroundChecker _groundChecker;
    private SmoothHealthBarView _healthBarView;
    private VampirismAbility _vampirismAbility;

    private void OnDisable()
    {
        _mover.SpeedChanged -= _animator.SetSpeed;
        _input.AttackPressed -= _animator.PlayAttack;
        _health.Damaged -= _animator.PlayTakeDamage;
        _health.Died -= OnDie;
        _input.VampirismPressed -= _vampirismAbility.TryActivate;
    }

    public void Initialize()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _mover = GetComponent<PlayerMover>();
        _jumper = GetComponent<PlayerJumper>();
        _health = GetComponent<Health>();
        _attacker = GetComponent<PlayerAttacker>();
        _collector = GetComponent<PlayerCollector>();
        _wallet = GetComponent<PlayerWallet>();
        _vision = GetComponent<PlayerVision>();
        _vampirismAbility = GetComponent<VampirismAbility>();
        _flipper = GetComponentInChildren<Flipper>();
        _animator = GetComponentInChildren<CharacterAnimator>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
        _healthBarView = GetComponentInChildren<SmoothHealthBarView>();

        _mover.Initialize(_rigidbody, _flipper);
        _jumper.Initialze(_rigidbody);
        _health.Initialize();
        _animator.Initialize();
        _collector.Initialize(_wallet, _health);
        _flipper.Initialize();
        _groundChecker.Initialize();
        _healthBarView.Initialize(_health);
        _vampirismAbility.Initialize(_health, _vision);

        _mover.SpeedChanged += _animator.SetSpeed;
        _input.AttackPressed += _animator.PlayAttack;
        _health.Damaged += _animator.PlayTakeDamage;
        _health.Died += OnDie;
        _input.VampirismPressed += _vampirismAbility.TryActivate;
    }

    public void UpdateLogic()
    {
        if (_health.IsDead)
            return;

        _input.UpdateLogic();

        if(_input.IsAttackPressed)
            _attacker.Attack();

        if (_input.IsJumpPressed)
            _jumper.Jump();
    }

    public void FixedUpdateLogic()
    {
        if (_health.IsDead)
            return;

        _mover.Move(_input.DirectionX);
    }

    private void OnDie() 
    {
        _animator.PlayDie();
    }
}