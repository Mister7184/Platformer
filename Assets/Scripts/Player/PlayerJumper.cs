using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;

    public void Initialze(Rigidbody2D rigidbody, PlayerInput playerInput)
    {
        _rigidbody = rigidbody;
        _playerInput = playerInput;
    }

    public void Jump() 
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }
}
