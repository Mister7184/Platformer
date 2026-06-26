using UnityEngine;

public class PlayerMoveState : IPlayerState
{
    private PlayerContext _context;
    private PlayerStateMachine _stateMachine;

    private PlayerIdleState _idleState;
    private PlayerJumpState _jumpState;
    private PlayerAttackState _attackState;

    public PlayerMoveState(PlayerContext context, PlayerStateMachine stateMachine) 
    {
        _context = context;
        _stateMachine = stateMachine;
    }

    public void Initialize(PlayerIdleState idleState, PlayerJumpState jumpState, PlayerAttackState attackState)
    {
        _idleState = idleState;
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

        if (Mathf.Abs(_context.Input.DirectionX) < 0.1f)
        {
            _stateMachine.ChangeState(_idleState);
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
