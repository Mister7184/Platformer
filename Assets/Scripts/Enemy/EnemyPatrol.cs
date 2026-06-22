using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints;
    [SerializeField] private float _baseSpeed = 1f;


    private int _pointIndex;
    private float _closeDistance = 0.1f;
    private Flipper _flipper;
    private float _speed;
    private int _direction;
    private CharacterAnimator _animator;

    public void Initialize(Flipper flipper, CharacterAnimator animator)
    {
        _flipper = flipper;
        _animator = animator;

        _speed = _baseSpeed;
    }

    public void UpdateLogic()
    {
        Patrol();
    }

    public void SetDirection(float direction)
    {
        if (direction > 0)
            _pointIndex = _wayPoints.Count - 1;
        else
            _pointIndex = 0;
    }

    private void Patrol()
    {
        _animator.SetSpeed(_speed);

        if (_wayPoints.Count == 0)
            return;

        Transform point = _wayPoints[_pointIndex];

        transform.position = Vector2.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);

        if (ReachedPoint(point))
        {
            if (_pointIndex == 0)
                _direction = 1;
            else if (_pointIndex == _wayPoints.Count - 1)
                _direction = -1;

            _pointIndex += _direction;
        }
        Vector2 direction = point.position - transform.position;

        _flipper.Flip(direction.x);
    }

    private bool ReachedPoint(Transform point) 
    {
        Vector2 offset = point.position - transform.position;

        return offset.sqrMagnitude < _closeDistance * _closeDistance;
    }
}