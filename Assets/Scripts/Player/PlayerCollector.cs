using UnityEngine;

[RequireComponent(typeof(PlayerWallet), typeof(Health))]

public class PlayerCollector : MonoBehaviour
{
    private PlayerWallet _wallet;
    private Health _health;

    public PlayerWallet Wallet => _wallet;
    public Health Health => _health;

    public void Initialize(PlayerWallet wallet, Health health) 
    {
        _wallet = wallet;
        _health = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PickupItem pickup) == false)
            return;

        switch (pickup) 
        {
            case Coin:
                _wallet.AddCoin();
                break;

            case HealthPotion healthPotion:
                _health.AddHealth(healthPotion.HealAmount);
                break;
        }
        
        pickup.Collect();
    }
}
