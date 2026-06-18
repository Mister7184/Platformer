using UnityEngine;

public class Flipper : MonoBehaviour
{
    public void Flip(float directionX) 
    {
        if (directionX > 0)
            transform.rotation = Quaternion.identity;
        else if (directionX < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
