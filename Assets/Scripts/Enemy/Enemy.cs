using UnityEngine;

[RequireComponent(typeof(Flipper))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyPatrol _patrol;
    [SerializeField] private Vector3 _gizmosSize;
    [SerializeField] private Vector3 _triggerRadiusOffset;
    [SerializeField] private LayerMask _playerLayer;

    private Flipper _flipper;
    private float _direction = 1;

    public void Initialize() 
    {
        _flipper = GetComponent<Flipper>();

        _patrol.Initialize(_flipper);

        _flipper.DirectionChanged += OnDirectionChanged;
    }

    public void UseUpdateLogic()
    {
        _patrol.UpdateLogic();
        TrySeePlayer();
    }

    private void OnDirectionChanged(int direction)
    {
        if (_direction != direction)
        {
            _direction = direction;

            _triggerRadiusOffset = new Vector3(_triggerRadiusOffset.x * -1, _triggerRadiusOffset.y, _triggerRadiusOffset.z);
        }
    }

    private bool TrySeePlayer() 
    {
        Collider2D player = Physics2D.OverlapBox(transform.position + _triggerRadiusOffset, _gizmosSize, 0, _playerLayer);

        _patrol.ChangeSpeed(player != null);

        return player != null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position + _triggerRadiusOffset, _gizmosSize);
    }
}
