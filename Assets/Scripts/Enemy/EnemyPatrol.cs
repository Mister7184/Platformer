using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints;
    [SerializeField] private float _speed = 1f;

    private int _pointIndex;
    private float _closeDistance = 0.1f;
    private bool _isWork = true;
    private Coroutine _patrolRoutine;

    public void StartPatrol()
    {
        if (_patrolRoutine == null)
            _patrolRoutine = StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        while (_isWork)
        {
            if (_wayPoints.Count > 0)
            {

                Transform point = _wayPoints[_pointIndex];

                transform.position = Vector2.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);

                Vector2 offset = point.position - transform.position;

                if (offset.sqrMagnitude < _closeDistance * _closeDistance)
                    _pointIndex = (_pointIndex + 1) % _wayPoints.Count;

                Vector2 direction = point.position - transform.position;

                if (direction.x > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else if (direction.x < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }

            yield return null;
        }
    }
}