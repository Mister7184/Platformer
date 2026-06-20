using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState
{
    private EnemyContext _context;
    private EnemyStateMachine _stateMachine;

    private PatrolState _patrolState;
    private AttackState _attackState;

    public ChaseState(EnemyContext context, EnemyStateMachine stateMachine)
    {
        _context = context;
        _stateMachine = stateMachine;
    }

    public void Initialize(PatrolState patrolState, AttackState attackState)
    {
        _patrolState = patrolState;
        _attackState = attackState;
    }

    public void Enter()
    {

    }

    public void Update()
    {
        _context.Chaser.UpdateLogic();

        if (_context.Vision.CanSeePlayer() == false || _context.Vision.CanHearPlayer() == false)
            _stateMachine.ChangeState(_patrolState);

        if (_context.Attacker.CanAttack())
            _stateMachine.ChangeState(_attackState);
    }

    public void Exit()
    {
        _context.Patrol.SetDirection(_context.Chaser.Direction);
    }
}