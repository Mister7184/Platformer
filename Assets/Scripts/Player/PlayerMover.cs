using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 8f;
    [SerializeField] private float _acceleration = 6f;
    [SerializeField] private float _deceleation = 8f;

    private float _directionX;
    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;

    public void Initialize(Rigidbody2D rigidbody, PlayerInput playerInput)
    {
        _rigidbody = rigidbody;
        _playerInput = playerInput;
    }

    public void FixedUpdate()
    {
        _directionX = _playerInput.DirectionX;

        float targetSpeed = _directionX * _maxSpeed;

        float speedDifferent = targetSpeed - _rigidbody.velocity.x;

        float accelerationRate = Mathf.Abs(targetSpeed) > 0.1f ? _acceleration : _deceleation;

        float movement = speedDifferent * accelerationRate * Time.fixedDeltaTime;

        float currentVelocityX = NormalizedVelocityX(movement);

        _rigidbody.velocity = new Vector2(currentVelocityX, _rigidbody.velocity.y);

        ChangeFlipX();
    }

    private float NormalizedVelocityX(float movement) 
    {
        float normalVelocityX = _rigidbody.velocity.x + movement;

        if (Mathf.Abs(normalVelocityX) < 0.05f)
            normalVelocityX = 0;

        return normalVelocityX;
    }

    private void ChangeFlipX()
    {
        if (_directionX > 0)
            transform.eulerAngles = Vector3.zero;
        else if (_directionX < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }
}