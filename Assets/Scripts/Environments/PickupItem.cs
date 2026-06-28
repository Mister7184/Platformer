using System;
using UnityEngine;

public abstract class PickupItem : MonoBehaviour
{
    public Action<PickupItem> Picked;

    public void Collect() 
    {
        Picked?.Invoke(this);
    }
}
