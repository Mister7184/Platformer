using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;

    public void Initialze(Rigidbody2D rigidbody)
    {
        _rigidbody = rigidbody;
    }

    public void Jump() 
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }
}
