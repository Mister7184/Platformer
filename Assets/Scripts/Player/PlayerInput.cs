using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const KeyCode JumpKey = KeyCode.UpArrow;

    public float DirectionX { get; private set; }
    public bool IsJumpPressed { get; private set; }

    public void UpdateLogic()
    {
        DirectionX = Input.GetAxisRaw(HorizontalAxis);
        IsJumpPressed = Input.GetKeyDown(JumpKey);
    }
}
