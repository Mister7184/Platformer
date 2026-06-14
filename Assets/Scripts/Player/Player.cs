using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    private PlayerMover _mover;

    public void Awake()
    {
        _mover = GetComponent<PlayerMover>();
    }
}