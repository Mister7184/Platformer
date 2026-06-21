using UnityEngine;

public class HealthPotion : PickupItem
{
    [SerializeField] private int _healAmount = 5;

    public int HealAmount => _healAmount;

    public override void Collect(PlayerCollector collector)
    {
        collector.Health.AddHealth(_healAmount);
        Destroy(gameObject);
    }
}
