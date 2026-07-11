using UnityEngine;

public class VampirismHealthDrainer : MonoBehaviour
{
    [SerializeField] private float _damagePerSecond = 2f;

    private Health _ownerHealth;
    private float _accumulatedDamage;

    public void Reset()
    {
        _accumulatedDamage = 0;
    }

    public void Initialize(Health ownerHealth)
    {
        _ownerHealth = ownerHealth;
    }

    public void Drain(Health target)
    {
        if (target == null || target.IsDead)
            return;

        _accumulatedDamage += _damagePerSecond * Time.deltaTime;

        int damage = Mathf.FloorToInt(_accumulatedDamage);

        if (damage <= 0)
            return;

        _accumulatedDamage -= damage;

        int drainedHealth = target.Reduce(damage);

        _ownerHealth.AddHealth(drainedHealth);
    }
}
