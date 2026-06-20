using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth = 10;

    private int _currentHealth;

    public Action Damaged;
    public Action Died;

    public void Initialize()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage) 
    {
        _currentHealth -= damage;
        Damaged?.Invoke();

        if(_currentHealth <= 0)
            Died?.Invoke();
    }
}
