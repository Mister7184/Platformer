using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _playerLayer;

    public bool CanAttack() 
    {
        return Physics2D.OverlapCircle(transform.position, _radius, _playerLayer);
    }

    public void Attack() 
    {

    }
}
