using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IEnemyState
{
    private EnemyContext _context;
    private EnemyStateMachine _stateMachine;

    private ChaseState _chaseState;

    public AttackState(EnemyContext context, EnemyStateMachine stateMachine)
    {
        _context = context;
        _stateMachine = stateMachine;
    }

    public void Initialize(ChaseState chaseState)
    {
        _chaseState = chaseState;
    }

    public void Enter()
    {
        _context.Attacker.Attack();
    }

    public void Update()
    {
        if (_context.Attacker.CanAttack() == false)
            _stateMachine.ChangeState(_chaseState);
    }

    public void Exit()
    {

    }
}