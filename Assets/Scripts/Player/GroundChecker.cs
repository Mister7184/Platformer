using System.Collections;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _checkPoint;
    [SerializeField] private float _radius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    private WaitForSeconds _delay = new WaitForSeconds(0.1f);
    private bool _isWork = true;

    public bool IsGrounded { get; private set; }

    public void Initialize()
    {
        StartCoroutine(CheckGroundRoutine());
    }

    private IEnumerator CheckGroundRoutine()
    {
        while (_isWork)
        {
            IsGrounded = Physics2D.OverlapCircle(_checkPoint.position, _radius, _groundLayer);

            yield return _delay;
        }
    }
}
