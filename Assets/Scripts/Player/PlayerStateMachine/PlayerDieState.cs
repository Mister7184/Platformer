using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : IPlayerState
{
    private PlayerContext _context;

    public PlayerDieState(PlayerContext context)
    {
        _context = context;
    }

    public void Enter()
    {
        _context.Animator.PlayDie();
    }

    public void Update()
    {
    }

    public void FixedUpdate()
    {

    }

    public void Exit()
    {

    }
}
