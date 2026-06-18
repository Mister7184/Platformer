using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints;
    [SerializeField] private float _baseSpeed = 1f;
    [SerializeField] private float _accelerationSpeed = 3f;
    

    private int _pointIndex;
    private float _closeDistance = 0.1f;
    private Flipper _flipper;
    private float _speed;

    public void ChangeSpeed(bool hasPlayer) 
    {
        if (hasPlayer)
            _speed = _accelerationSpeed;
        else 
            _speed = _baseSpeed;
    }

    public void Initialize(Flipper flipper)
    {
        _flipper = flipper;

        _speed = _baseSpeed;
    }

    public void UpdateLogic()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (_wayPoints.Count == 0)
            return;

        Transform point = _wayPoints[_pointIndex];

        transform.position = Vector2.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);

        Vector2 offset = point.position - transform.position;

        if (offset.sqrMagnitude < _closeDistance * _closeDistance)
            _pointIndex = (_pointIndex + 1) % _wayPoints.Count;

        Vector2 direction = point.position - transform.position;

        _flipper.Flip(direction.x);
    }
}