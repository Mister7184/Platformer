using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : IPlayerState
{
    private PlayerContext _context;
    private PlayerStateMachine _stateMachine;

    private PlayerIdleState _idleState;
    private PlayerMoveState _moveState;

    public PlayerJumpState(PlayerContext context, PlayerStateMachine stateMachine)
    {
        _context = context;
        _stateMachine = stateMachine;
    }

    public void Initialize(PlayerIdleState idleState, PlayerMoveState moveState)
    {
        _idleState = idleState;
        _moveState = moveState;
    }

    public void Enter()
    {
        _context.Jumper.Jump();
    }

    public void Update()
    {
        if (_context.GroundChecker.IsGrounded()) 
        {
            if (Mathf.Abs(_context.Input.DirectionX) > 0)
                _stateMachine.ChangeState(_moveState);
            else
                _stateMachine.ChangeState(_idleState);
        }
    }

    public void FixedUpdate()
    {
        _context.Mover.FixedUpdateLogic();
    }

    public void Exit()
    {

    }
}
