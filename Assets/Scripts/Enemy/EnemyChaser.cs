using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _deadZone = 0.5f;

    private Flipper _flipper;
    private int _direction;
    private CharacterAnimator _animator;

    public int Direction => _direction;

    public void Initialize(Flipper flipper, CharacterAnimator animator)
    {
        _flipper = flipper;
        _animator = animator;
    }

    public void MoveTo(Transform target)
    {
        _animator.SetSpeed(_speed);

        Transform left = _waypoints[0];
        Transform right = _waypoints[_waypoints.Count - 1];

        float targetDirectionX = Mathf.Clamp(target.position.x, left.position.x, right.position.x);

        Vector2 targetPosition = new Vector2(targetDirectionX, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

        float deltaX = target.position.x - transform.position.x;

        if (Mathf.Abs(deltaX) > _deadZone)
        {
            _direction  = deltaX > 0 ? 1 : -1;
            _flipper.Flip(_direction);
        }
    }
}