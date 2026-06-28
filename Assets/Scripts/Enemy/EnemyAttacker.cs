using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _radius = 0.5f;
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _attackDelay = 1f;

    private CharacterAnimator _animator;
    private float _timer;

    public void Initialize(CharacterAnimator animator) 
    {
        _animator = animator;
    }

    public bool HasTarget()
    {
        return Physics2D.OverlapCircle(transform.position, _radius, _playerLayer);
    }

    public void Attack()
    {
        _timer -= Time.deltaTime;
        
        if (_timer > 0)
            return;

        _timer = _attackDelay;

        _animator.SetSpeed(0f);
        _animator.PlayAttack();

        Collider2D player = Physics2D.OverlapCircle(transform.position, _radius, _playerLayer);

        if (player == null)
            return;

        if (player.TryGetComponent(out IDamageable damageable))
            damageable.TakeDamage(_damage);
    }
}