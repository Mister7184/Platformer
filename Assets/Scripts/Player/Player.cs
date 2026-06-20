using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(PlayerMover),  typeof(PlayerJumper))]
[RequireComponent(typeof(Flipper), typeof(Health))]

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerMover _mover;
    private CharacterAnimator _animator;
    private PlayerJumper _playerJumper;
    private PlayerInput _playerInput;
    private Flipper _flipper;
    private Health _health;

    public void Initialize()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _flipper = GetComponent<Flipper>();
        _mover = GetComponent<PlayerMover>();
        _playerJumper = GetComponent<PlayerJumper>();
        _health = GetComponent<Health>();
        _animator = GetComponentInChildren<CharacterAnimator>();

        _mover.Initialize(_rigidbody, _playerInput, _flipper);
        _playerJumper.Initialze(_rigidbody, _playerInput);
        _health.Initialize();
        _animator.Initialize();
    }

    public void UseUpdateLogic() 
    {
        _playerInput.UpdateLogic();
        _playerJumper.UpdateLogic();
    }

    public void UseFixedUpdateLogic() 
    {
        _mover.FixedUpdateLogic();
    }
}