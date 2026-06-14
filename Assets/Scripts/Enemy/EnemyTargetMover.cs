using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints;
    [SerializeField] private float _speed = 1f;

    private int _pointIndex;
    private float _closeDistance = 0.1f;

    private void Update() // В куратину
    {
        if (_wayPoints.Count == 0)
            return;

        Transform point = _wayPoints[_pointIndex];

        transform.position = Vector2.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);

        Vector2 offset = point.position - transform.position;

        if (offset.sqrMagnitude < _closeDistance * _closeDistance)
            _pointIndex = (_pointIndex + 1) % _wayPoints.Count;
    }
}