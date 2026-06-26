using UnityEngine;

public class PlayerHitState : IPlayerState
{
    private PlayerContext _context;
    private PlayerStateMachine _stateMachine;

    private PlayerMoveState _moveState;
    private PlayerIdleState _idleState;
    private PlayerJumpState _jumpState;

    private float _timer;
    private float _hitDuration = 0.3f;

    public PlayerHitState(PlayerContext context, PlayerStateMachine stateMachine)
    {
        _context = context;
        _stateMachine = stateMachine;
    }

    public void Initialize(PlayerMoveState moveState, PlayerIdleState idleState, PlayerJumpState jumpState)
    {
        _moveState = moveState;
        _idleState = idleState;
        _jumpState = jumpState;
    }

    public void Enter()
    {
        _timer = _hitDuration;

        _context.Animator.PlayTakeDamage();
    }

    public void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            if (_context.GroundChecker.IsGrounded())
            {
                if (Mathf.Abs(_context.Input.DirectionX) > 0)
                    _stateMachine.ChangeState(_moveState);
                else
                    _stateMachine.ChangeState(_idleState);
            }
            else
            {
                _stateMachine.ChangeState(_jumpState);
            }
        }
    }

    public void FixedUpdate()
    {

    }

    public void Exit()
    {
    }
}
