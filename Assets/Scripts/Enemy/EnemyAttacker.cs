using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _radius = 0.5f;
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _playerLayer;

    private CharacterAnimator _animator;

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
        _animator.PlayAttack();

        Collider2D player = Physics2D.OverlapCircle(transform.position, _radius, _playerLayer);

        if (player == null)
            return;

        if (player.TryGetComponent(out IDamageable damageable))
            damageable.TakeDamage(_damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawSphere(transform.position, _radius);
    }
}