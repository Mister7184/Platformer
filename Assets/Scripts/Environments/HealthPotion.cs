using UnityEngine;

public class HealthPotion : PickupItem
{
    [SerializeField] private int _healAmount = 5;

    public int HealAmount => _healAmount;
}
