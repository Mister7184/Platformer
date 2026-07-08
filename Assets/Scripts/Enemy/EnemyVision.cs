using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [Header("Layer")]
    [SerializeField] private LayerMask _playerLayer;

    [Header("Vision")]
    [SerializeField] private Vector3 _seeSize;
    [SerializeField] private Vector3 _visionOffset;

    [Header("Hearing")]
    [SerializeField] private Vector3 _hearSize;
    [SerializeField] private Vector3 _hearOffset;


    private Flipper _flipper;

    public void Initialize(Flipper flipper)
    {
        _flipper = flipper;
    }

    public bool TryGetPlayer(out Transform player) 
    {
        if(CanSeePlayer(out player))
            return true;

        if (CanHearPlayer(out player))
            return true;

        return false;
    }

    private bool CanSeePlayer(out Transform player)
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position + VisionOffset, _seeSize, 0, _playerLayer);

        if (collider == null) 
        {
            player = null;
            return false;
        }

        player = collider.transform;
        return true;
    }

    private bool CanHearPlayer(out Transform player) 
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position + HearOffset, _hearSize, 0, _playerLayer);

        if (collider == null)
        {
            player = null;
            return false;
        }

        player = collider.transform;
        return true;
    }

    private Vector3 VisionOffset => new Vector3(_visionOffset.x * _flipper.Direction, _visionOffset.y, 0);
    private Vector3 HearOffset => new Vector3(_hearOffset.x * _flipper.Direction, _hearOffset.y, 0);

    private void OnDrawGizmosSelected()
    {
        if (_flipper == null)
            return;

        Gizmos.color = Color.green;

        float direction = _flipper != null ? _flipper.Direction : 1;

        Vector3 offset = new Vector3(
        _hearOffset.x * direction,
        _hearOffset.y,
        _hearOffset.z);

        Gizmos.DrawWireCube(transform.position + offset, _hearSize);
    }
}
