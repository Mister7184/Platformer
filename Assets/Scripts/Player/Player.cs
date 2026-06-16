using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(PlayerMover),  typeof(PlayerJumper))]
[RequireComponent(typeof(Flipper))]

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerMover _mover;
    private PlayerAnimator _animator;
    private PlayerJumper _playerJumper;
    private PlayerInput _playerInput;
    private Flipper _flipper;

    public void Initialize()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _flipper = GetComponent<Flipper>();
        _mover = GetComponent<PlayerMover>();
        _playerJumper = GetComponent<PlayerJumper>();
        _animator = GetComponentInChildren<PlayerAnimator>();

        _mover.Initialize(_rigidbody, _playerInput, _flipper);
        _playerJumper.Initialze(_rigidbody, _playerInput);
        _animator.Initialize(_rigidbody);
    }

    public void UseUpdateLogic() 
    {
        _playerInput.UpdateLogic();
        _playerJumper.UpdateLogic();
        _animator.UpdateLogic();
    }

    public void UseFixedUpdateLogic() 
    {
        _mover.FixedUpdateLogic();
    }
}