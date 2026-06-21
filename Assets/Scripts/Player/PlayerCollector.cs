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
        _wallet = GetComponent<PlayerWallet>();
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<PickupItem>(out PickupItem pickup)) 
        {
            pickup.Collect(this);
        }
    }
}
