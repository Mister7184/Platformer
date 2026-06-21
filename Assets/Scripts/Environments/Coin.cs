using UnityEngine;

public class Coin : PickupItem
{
    public override void Collect(PlayerCollector collector) 
    {
        Debug.Log(collector);
        Debug.Log(collector.Wallet);

        collector.Wallet.AddCoin();
        DestroySelf();
    }
}
