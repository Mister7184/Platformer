using UnityEngine;

public abstract class PickupItem : MonoBehaviour
{
    public abstract void Collect(PlayerCollector collector);

    protected void DestroySelf() 
    {
        Destroy(gameObject);
    }
}
