using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 8f;
    [SerializeField] private float _acceleration = 6f;
    [SerializeField] private float _deceleation = 8f;

    private float _directionX;
    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;
    private Flipper _flipper;
    private CharacterAnimator _animator;

    public void Initialize(Rigidbody2D rigidbody, PlayerInput playerInput, Flipper flipper, CharacterAnimator animator)
    {
        _rigidbody = rigidbody;
        _playerInput = playerInput;
        _flipper = flipper;
        _animator = animator;
    }

    public void FixedUpdateLogic()
    {
        _directionX = _playerInput.DirectionX;

        float targetSpeed = _directionX * _maxSpeed;
        float speedDifferent = targetSpeed - _rigidbody.velocity.x;

        float accelerationRate = Mathf.Abs(targetSpeed) > 0.1f ? _acceleration : _deceleation;

        float movement = speedDifferent * accelerationRate * Time.fixedDeltaTime;
        float currentVelocityX = NormalizedVelocityX(movement);

        _rigidbody.velocity = new Vector2(currentVelocityX, _rigidbody.velocity.y);

        _animator.SetSpeed(MathF.Abs(currentVelocityX));

        _flipper.Flip(_directionX);
    }

    private float NormalizedVelocityX(float movement) 
    {
        float normalVelocityX = _rigidbody.velocity.x + movement;

        if (Mathf.Abs(normalVelocityX) < 0.05f)
            normalVelocityX = 0;

        return normalVelocityX;
    }
}