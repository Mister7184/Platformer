using UnityEngine;

[RequireComponent(typeof(Flipper), typeof(EnemyPatrol), typeof(EnemyVision))]
[RequireComponent(typeof(EnemyChaser))]

public class Enemy : MonoBehaviour
{
    private EnemyPatrol _patrol;
    private EnemyVision _vision;
    private EnemyAttacker _attacker;
    private EnemyChaser _chaser;
    private Flipper _flipper;

    private EnemyStateMachine _stateMachine;

    private PatrolState _patrolState;
    private ChaseState _chaseState;
    private AttackState _attackState;

    private EnemyContext _context;

    public void Initialize(Transform player) 
    {
        _flipper = GetComponent<Flipper>();
        _patrol = GetComponent<EnemyPatrol>();
        _vision = GetComponent<EnemyVision>();
        _attacker = GetComponent<EnemyAttacker>();
        _chaser = GetComponent<EnemyChaser>();

        _context = new EnemyContext()
        {
            Player = player,
            Vision = _vision,
            Patrol = _patrol,
            Attacker = _attacker,
            Chaser = _chaser,
            Flipper = _flipper
        };

        _stateMachine = new EnemyStateMachine();

        _patrolState = new PatrolState(_context, _stateMachine);
        _chaseState = new ChaseState();
        _attackState = new AttackState();

        
    }
}
