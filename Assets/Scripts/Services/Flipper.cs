using System;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public int Direction { get; private set; }

    public void Flip(float directionX)
    {
        if (directionX > 0)
        {
            transform.rotation = Quaternion.identity;
            Direction = 1;
        }
        else if (directionX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            Direction = -1;
        }
    }
}
