using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _radius = 1.5f;
    [SerializeField] private int _damage = 5;
    [SerializeField] private LayerMask _enemyLayer;

    private CharacterAnimator _animator;

    public void Initialize(CharacterAnimator animator) 
    {
        _animator = animator;
    }

    public void Attack() 
    {
        _animator.PlayAttack();

        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _radius, _enemyLayer);

        foreach (Collider2D enemy in enemies) 
        {
            if (enemy.TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(_damage);
        }
    }
}
