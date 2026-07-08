using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const float VelocityThreshold = 0.05f;

    [SerializeField] private float _maxSpeed = 8f;
    [SerializeField] private float _acceleration = 6f;
    [SerializeField] private float _deceleation = 8f;

    private float _directionX;
    private Rigidbody2D _rigidbody;
    private Flipper _flipper;

    public Action<float> SpeedChanged;

    public void Initialize(Rigidbody2D rigidbody, Flipper flipper)
    {
        _rigidbody = rigidbody;
        _flipper = flipper;
    }

    public void Move(float directionX)
    {
        _directionX = directionX;

        float targetSpeed = _directionX * _maxSpeed;
        float speedDifferent = targetSpeed - _rigidbody.velocity.x;

        float accelerationRate = Mathf.Abs(targetSpeed) > 0.1f ? _acceleration : _deceleation;

        float movement = speedDifferent * accelerationRate * Time.fixedDeltaTime;
        float currentVelocityX = NormalizedVelocityX(movement);

        _rigidbody.velocity = new Vector2(currentVelocityX, _rigidbody.velocity.y);

        SpeedChanged?.Invoke(MathF.Abs(currentVelocityX));

        _flipper.Flip(_directionX);
        Debug.Log(_directionX);
    }

    private float NormalizedVelocityX(float movement) 
    {
        float normalVelocityX = _rigidbody.velocity.x + movement;

        if (Mathf.Abs(normalVelocityX) < VelocityThreshold)
            normalVelocityX = 0;

        return normalVelocityX;
    }
}