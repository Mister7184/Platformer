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
        if (damage < 0)
            return;

        if (IsDead)
            return;

        _current = Mathf.Clamp(_current - damage, 0, _max);
        
        Refresh();

        if (IsDead)
            Died?.Invoke();
        else
            Damaged?.Invoke();
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