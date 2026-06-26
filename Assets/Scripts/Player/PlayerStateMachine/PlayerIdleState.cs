using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    private PlayerContext _context;
    private PlayerStateMachine _stateMachine;

    private PlayerMoveState _moveState;
    private PlayerJumpState _jumpState;
    private PlayerAttackState _attackState;

    public PlayerIdleState(PlayerContext context, PlayerStateMachine stateMachine) 
    {
        _context = context;
        _stateMachine = stateMachine;
    }

    public void Initialize(PlayerMoveState moveState, PlayerJumpState jumpState, PlayerAttackState attackState) 
    {
        _moveState = moveState;
        _jumpState = jumpState;
        _attackState = attackState;
    }

    public void Enter() 
    {

    }

    public void Update() 
    {
        if (_context.Input.IsAttackPressed) 
        {
            _stateMachine.ChangeState(_attackState);
            return;
        }

        if (_context.Input.IsJumpPressed) 
        {
            _stateMachine.ChangeState(_jumpState);
        }

        if (Mathf.Abs(_context.Input.DirectionX) > 0) 
        {
            _stateMachine.ChangeState(_moveState);
        }
    }

    public void FixedUpdate() 
    {
        _context.Mover.FixedUpdateLogic(_context.Input.DirectionX);
    }

    public void Exit() 
    {

    }
}
