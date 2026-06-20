using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _deadZone = 0.5f;

    private Transform _player;
    private Flipper _flipper;
    private int _direction;

    public int Direction => _direction;

    public void Initialize(Transform player, Flipper flipper)
    {
        _player = player;
        _flipper = flipper;
    }

    public void UpdateLogic()
    {
        Transform left = _waypoints[0];
        Transform right = _waypoints[_waypoints.Count - 1];

        float targetDirectionX = Mathf.Clamp(_player.position.x, left.position.x, right.position.x);

        Vector2 targetPosition = new Vector2(targetDirectionX, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

        float deltaX = _player.position.x - transform.position.x;

        if (Mathf.Abs(deltaX) > _deadZone)
        {
            _direction  = deltaX > 0 ? 1 : -1;
            _flipper.Flip(_direction);
        }
    }
}