using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public float DirectionX { get; private set; }

    public bool IsMoving => Mathf.Abs(DirectionX) > 0.1f;

    public void SetDirectionX(float value) 
    {
        DirectionX = value;
    }
}
