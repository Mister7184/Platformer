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
        _currentHealth -= damage;

        if (_currentHealth <= 0)
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
        _currentHealth = Mathf.Min(_currentHealth + value, _maxHealth);
    }
}