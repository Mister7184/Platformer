using System;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public Action<int> DirectionChanged; 

    public void Flip(float directionX)
    {
        if (directionX > 0)
        {
            transform.rotation = Quaternion.identity;
            DirectionChanged?.Invoke(1);
        }
        else if (directionX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            DirectionChanged?.Invoke(-1);
        }
    }
}
