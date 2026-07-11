using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    private const int MaxTargets = 10;

    [SerializeField] private float _range = 3f;
    [SerializeField] private LayerMask _enemyLayer;

    private readonly Collider2D[] _results = new Collider2D[MaxTargets];

    public bool TryGetClosestEnemy(out Health closestEnemyHealth) 
    {
        closestEnemyHealth = null;

        int targetsCount = Physics2D.OverlapCircleNonAlloc(
            transform.position, _range, _results, _enemyLayer);

        float closestDistance = float.MaxValue;

        for (int i = 0; i < targetsCount; i++)
        {
            Health enemyHealth = _results[i].GetComponentInParent<Health>();

            if(enemyHealth == null || enemyHealth.IsDead)
                continue;

            Vector2 direction = enemyHealth.transform.position - transform.position;

            float distance = direction.sqrMagnitude;

            if(distance >= closestDistance)
                continue;

            closestDistance = distance;
            closestEnemyHealth = enemyHealth;
        }
        return closestEnemyHealth != null;
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
