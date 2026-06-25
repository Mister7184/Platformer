using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const KeyCode JumpKey = KeyCode.UpArrow;
    private const KeyCode AttackKey = KeyCode.Space;

    public float DirectionX { get; private set; }
    public bool IsJumpPressed { get; private set; }
    public bool IsAttackPressed { get; private set; }

    public void UpdateLogic()
    {
        DirectionX = Input.GetAxisRaw(HorizontalAxis);
        IsJumpPressed = Input.GetKeyDown(JumpKey);
        IsAttackPressed = Input.GetKeyDown(AttackKey);
    }
}
