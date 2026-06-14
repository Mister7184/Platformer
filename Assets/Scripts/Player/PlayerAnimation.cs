using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator)))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    public void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool("IsMoving", Mathf.Abs(DirectionX) > 0.1f);
    }
}
