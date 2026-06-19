using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private float _speed;

    private Transform _player;
    private Flipper _flipper;

    public void Initialize(Transform player, Flipper flipper) 
    {
        _player = player;
        _flipper = flipper;
    }

    public void UpdateLogic() 
    {
        Transform left = _waypoints[0];
        Transform right = _waypoints[_waypoints.Count - 1];

        Vector3 targetPosition = _player.position;

        targetPosition.x = Mathf.Clamp(targetPosition.x, left.position.x, right.position.x);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

        _flipper.Flip(targetPosition.x - transform.position.x);
    }
}
