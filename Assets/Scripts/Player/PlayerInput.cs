using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float _directionX;
    private bool _isJumpPressed;

    public float DirectionX => _directionX;
    public bool IsJumpPressed => _isJumpPressed;

    private void Update()
    {
        _directionX = Input.GetAxisRaw("Horizontal");
        _isJumpPressed = Input.GetKeyDown(KeyCode.Space);
    }
}
