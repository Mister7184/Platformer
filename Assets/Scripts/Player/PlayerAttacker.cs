using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    private const int MaxPotentialTargets = 10;
    
    [SerializeField] private float _radius = 1.5f;
    [SerializeField] private int _damage = 5;
    [SerializeField] private LayerMask _enemyLayer;

    private readonly Collider2D[] _hitBuffer = new Collider2D[MaxPotentialTargets];

    public void Attack()
    {
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _hitBuffer, _enemyLayer);

        for (int i = 0; i < count; i++)
        {
            if (_hitBuffer[i].TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(_damage);
        }
    }
}
