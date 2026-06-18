using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private Vector3 _size;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private LayerMask _playerLayer;

    private Flipper _flipper;

    public void Initialize(Flipper flipper)
    {
        _flipper = flipper;
    }
    public bool HasPlayer()
    {
        Debug.Log(_flipper.Direction);
        return Physics2D.OverlapBox(transform.position + CurrentOffset, _size, 0, _playerLayer);
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
