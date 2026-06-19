using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [Header("Layer")]
    [SerializeField] private LayerMask _playerLayer;

    [Header("Vision")]
    [SerializeField] private Vector3 _size;
    [SerializeField] private Vector3 _offset;

    [Header("Hearing")]
    [SerializeField] private float _hearingRadius;

    private Flipper _flipper;

    public void Initialize(Flipper flipper)
    {
        _flipper = flipper;
    }
    public bool CanSeePlayer()
    {
        return Physics2D.OverlapBox(transform.position + CurrentOffset, _size, 0, _playerLayer);
    }

    public bool CanHearPlayer() 
    {
        return Physics2D.OverlapCircle(transform.position, _hearingRadius, _playerLayer);
    }

    private Vector3 CurrentOffset => new Vector3(_offset.x * _flipper.Direction, _offset.y, 0);

    private void OnDrawGizmosSelected()
    {
        if (_flipper == null)
            return;

        Gizmos.color = Color.green;

        float direction = _flipper != null ? _flipper.Direction : 1;

        Vector3 offset = new Vector3(
        _offset.x * direction,
        _offset.y,
        _offset.z);

        Gizmos.DrawWireCube(transform.position + offset, _size);
    }
}
