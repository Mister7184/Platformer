using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _max = 10;

    private int _current;

    public bool IsDead => _current <= 0;

    public Action Died;
    public Action Damaged;
    public Action<int, int> Changed;

    public void Initialize()
    {
        _current = _max;
    }

    public void TakeDamage(int damage)
    {
        Reduce(damage);
    }

    public int Reduce(int damage) 
    {
        if (damage <= 0 || IsDead)
            return 0;

        int previousValue = _current;

        _current = Mathf.Clamp(_current - damage, 0, _max);

        int appliedDamage = previousValue - _current;

        Refresh();

        if (IsDead)
            Died?.Invoke();
        else
            Damaged?.Invoke();

        return appliedDamage;
    }

    public void AddHealth(int value)
    {
        if (value < 0)
            return;

        if (IsDead)
            return;

        _current = Mathf.Clamp(_current + value, 0, _max);

        Refresh();
    }

    public void Refresh()
    {
        Changed?.Invoke(_current, _max);
    }
}