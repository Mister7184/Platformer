using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    private const string SpeedFloatName = "Speed";

    public readonly int Speed = Animator.StringToHash(SpeedFloatName);

    private Animator _animator;
    private PlayerMover _mover;

    public void Initialize(PlayerMover mover)
    {
        _animator = GetComponent<Animator>();
        _mover = mover;

        _mover.SpeedChanged += OnSpeedChanged;
    }

    public void OnSpeedChanged(float moveSpeed)
    {
        _animator.SetFloat(Speed, moveSpeed);
    }

    private void OnDisable()
    {
        _mover.SpeedChanged -= OnSpeedChanged;
    }
}
