using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const KeyCode JumpKey = KeyCode.W;
    private const KeyCode AttackKey = KeyCode.Space;
    private const KeyCode VampirismKey = KeyCode.E;

    public float DirectionX { get; private set; }
    public bool IsJumpPressed { get; private set; }
    public bool IsAttackPressed { get; private set; }

    public Action AttackPressed;
    public Action VampirismPressed;

    public void UpdateLogic()
    {
        DirectionX = Input.GetAxisRaw(HorizontalAxis);
        IsJumpPressed = Input.GetKeyDown(JumpKey);
        IsAttackPressed = Input.GetKeyDown(AttackKey);

        if (IsAttackPressed)
            AttackPressed?.Invoke();

        if(Input.GetKeyDown(VampirismKey))
            VampirismPressed?.Invoke();
    }
}
