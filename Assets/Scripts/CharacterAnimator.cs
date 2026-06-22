using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CharacterAnimator : MonoBehaviour
{
    private const string SpeedFloatName = "Speed";
    private const string DamageTriggerName = "IsDamaged";
    private const string DieTriggerName = "IsDied";
    private const string AttackTriggerName = "IsAttack";

    public readonly int Speed = Animator.StringToHash(SpeedFloatName);
    public readonly int Hit = Animator.StringToHash(DamageTriggerName);
    public readonly int Die = Animator.StringToHash(DieTriggerName);
    public readonly int Attack = Animator.StringToHash(AttackTriggerName);

    private Animator _animator;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
    }

    public bool IsPlaying(string stateName) 
    {
        return _animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    public void SetSpeed(float moveSpeed)
    {
        _animator.SetFloat(Speed, moveSpeed);
    }

    public void PlayTakeDamage() 
    {
        Debug.Log("PlayTakeDamage " + gameObject.name);
        _animator.SetTrigger(Hit);
    }

    public void PlayDie() 
    {
        _animator.SetTrigger(Die);
    }

    public void PlayAttack()
    {
        Debug.Log("Attack " + gameObject.name);
        _animator.SetTrigger(Attack);
    }
}
