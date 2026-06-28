using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth = 10;

    private int _currentHealth;

    public Action Damaged;
    public Action Died;

    public bool IsDead => _currentHealth <= 0;

    public void Initialize()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            return;

        if (IsDead) 
            return;

        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);

        if (IsDead)
        {
            _currentHealth = 0;
            Died?.Invoke();
        }
        else
        {
            Damaged?.Invoke();
        }
    }

    public void AddHealth(int value)
    {
        if (value < 0)
            return;

        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, _maxHealth);
    }
}