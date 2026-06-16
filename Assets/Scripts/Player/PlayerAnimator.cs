using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    public void Initialize(Rigidbody2D rigidbody)
    {
        _animator = GetComponent<Animator>();
        _rigidbody = rigidbody;
    }

    private void Update()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
    }
}
