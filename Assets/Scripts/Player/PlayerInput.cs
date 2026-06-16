using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const KeyCode JumpKey = KeyCode.UpArrow;

    private float _directionX;
    private bool _isJumpPressed;

    public float DirectionX => _directionX;
    public bool IsJumpPressed => _isJumpPressed;

    public void UpdateLogic()
    {
        _directionX = Input.GetAxisRaw(HorizontalAxis);
        _isJumpPressed = Input.GetKeyDown(JumpKey);
    }
}
