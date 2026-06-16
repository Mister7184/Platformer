using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyPatrol _patrol;

    public void Activate() 
    {
        _patrol.StartPatrol();
    }
}
