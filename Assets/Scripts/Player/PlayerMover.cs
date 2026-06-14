using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private float _directionX;

    public Action<float> IsMoved;
    public float DirectionX => _directionX;

    public void Update()
    {
        _directionX = Input.GetAxis("Horizontal");

        transform.position = new Vector3(transform.position.x + _directionX * _speed * Time.deltaTime, transform.position.y, 0);

        IsMoved.Invoke(_directionX);

        ChangeFlipX();
    }

    private void ChangeFlipX()
    {
        if (_directionX > 0)
            transform.eulerAngles = Vector3.zero;
        else if (_directionX < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }
}