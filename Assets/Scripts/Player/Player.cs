using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(PlayerMover),  typeof(PlayerJumper))]

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerMover _mover;
    private PlayerAnimator _animator;
    private PlayerJumper _playerJumper;
    private PlayerInput _playerInput;

    public void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _mover = GetComponent<PlayerMover>();
        _playerJumper = GetComponent<PlayerJumper>();
        _animator = GetComponentInChildren<PlayerAnimator>();
        _playerInput = GetComponent<PlayerInput>();

        _mover.Initialize(_rigidbody, _playerInput);
        _playerJumper.Initialze(_rigidbody, _playerInput);
        _animator.Initialize(_rigidbody);
    }
}