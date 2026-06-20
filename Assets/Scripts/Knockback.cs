using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knockback : MonoBehaviour, IKnockbackable
{
    private Rigidbody2D _rigidbody;

    public void Initialize(Rigidbody2D rigidbody) 
    {
        _rigidbody = rigidbody;
    }

    public void ApplyKnockback(Vector2 direction, float force) 
    {
        _rigidbody.velocity = Vector2.zero;

        _rigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
    }
}
