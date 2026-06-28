using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Quaternion _rightRotation;
    private Quaternion _leftRotation;

    public int Direction { get; private set; }

    public void Initialize() 
    {
        _rightRotation = Quaternion.identity;
        _leftRotation = Quaternion.Euler(0, 180, 0);
    }

    public void Flip(float directionX)
    {
        if (directionX > 0 && Direction != 1)
        {
            transform.rotation = _rightRotation;
            Direction = 1;
        }
        else if (directionX < 0 && Direction != -1)
        {
            transform.rotation = _leftRotation;
            Direction = -1;
        }
    }
}
