public class Coin : PickupItem
{
    public override void Collect(PlayerCollector collector) 
    {
        collector.Wallet.AddCoin();
        DestroySelf();
    }
}
