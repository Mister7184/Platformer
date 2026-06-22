using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(PlayerMover),  typeof(PlayerJumper))]
[RequireComponent(typeof(Flipper), typeof(Health), typeof(PlayerAttacker))]
[RequireComponent(typeof(PlayerCollector), typeof(PlayerWallet))]

public class Player : MonoBehaviour
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

    public bool IsDead { get; private set; }

    private void OnDisable()
    {
        _mover.SpeedChanged -= _animator.SetSpeed;
        _input.AttackPressed -= _animator.PlayAttack;
        _input.AttackPressed -= _attacker.Attack;
        _health.Damaged -= _animator.PlayTakeDamage;
        _health.Died -= Die;
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

        _mover.Initialize(_rigidbody, _input, _flipper);
        _jumper.Initialze(_rigidbody, _input);
        _health.Initialize();
        _animator.Initialize();
        _collector.Initialize(_wallet, _health);

        _mover.SpeedChanged += _animator.SetSpeed;
        _input.AttackPressed += _animator.PlayAttack;
        _input.AttackPressed += _attacker.Attack;
        _health.Damaged += _animator.PlayTakeDamage;
        _health.Died += Die;
    }

    public void UseUpdateLogic() 
    {
        _input.UpdateLogic();
        _jumper.UpdateLogic();
    }

    public void UseFixedUpdateLogic() 
    {
        _mover.FixedUpdateLogic();
    }

    private void Die() 
    {
        IsDead = true;

        _animator.PlayDie();
    }
}