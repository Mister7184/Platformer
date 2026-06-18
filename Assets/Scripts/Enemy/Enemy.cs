using UnityEngine;

[RequireComponent(typeof(Flipper))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyPatrol _patrol;
    private Flipper _flipper;

    public void Activate() 
    {
        _flipper = GetComponent<Flipper>();

        _patrol.Initialize(_flipper);

        _patrol.StartPatrol();
    }
}
