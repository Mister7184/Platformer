using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    private const string SpeedFloatName = "Speed";
    private const string DamageTriggerName = "IsDamaged";
    private const string DieTriggerName = "IsDied";
    private const string AttackTriggerName = "IsDied";

    public readonly int Speed = Animator.StringToHash(SpeedFloatName);
    public readonly int Hit = Animator.StringToHash(DamageTriggerName);
    public readonly int Die = Animator.StringToHash(DieTriggerName);
    public readonly int Attack = Animator.StringToHash(AttackTriggerName);

    private Animator _animator;
    private PlayerMover _mover;
    private Health _health;
    private PlayerInput _input;

    private void OnDisable()
    {
        _mover.SpeedChanged -= OnSpeedChanged;
        _health.Damaged -= OnDamaged;
        _health.Died -= OnDied;
    }

    public void Initialize(PlayerMover mover, Health health, PlayerInput input)
    {
        _animator = GetComponent<Animator>();
        _mover = mover;
        _health = health;
        _input = input;

        _mover.SpeedChanged += OnSpeedChanged;
        _health.Damaged += OnDamaged;
        _health.Died += OnDied;
        _input.AttackPressed += OnAttackPressed;
    }

    private void OnSpeedChanged(float moveSpeed)
    {
        _animator.SetFloat(Speed, moveSpeed);
    }

    private void OnDamaged() 
    {
        _animator.SetTrigger(Hit);
    }

    private void OnDied() 
    {
        _animator.SetTrigger(Die);
    }

    private void OnAttackPressed() 
    {
        _animator.SetTrigger(Attack);
    }
}
