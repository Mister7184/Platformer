using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _checkPoint;
    [SerializeField] private float _radius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGrounded() 
    {
        return Physics2D.OverlapCircle(_checkPoint.position, _radius, _groundLayer);
    }
}
