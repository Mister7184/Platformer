using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _radius = 1.5f;
    [SerializeField] private int _damage = 5;
    [SerializeField] private LayerMask _enemyLayer;

    public void Attack() 
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _radius, _enemyLayer);

        foreach (Collider2D enemy in enemies) 
        {
            if (enemy.TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(_damage);
        }
    }
}
