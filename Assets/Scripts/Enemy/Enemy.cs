using UnityEngine;

[RequireComponent(typeof(EnemyPatrol), typeof(EnemyVision))]
[RequireComponent(typeof(EnemyChaser), typeof(EnemyAttacker), typeof(Health))]

public class Enemy : MonoBehaviour, IUpdatable
{
    private EnemyPatrol _patrol;
    private EnemyVision _vision;
    private EnemyAttacker _attacker;
    private EnemyChaser _chaser;
    private Flipper _flipper;
    private CharacterAnimator _animator;
    private Health _health;
    private SmoothHealthBarView _healthBarView;

    private void OnDisable()
    {
        _health.Damaged -= _animator.PlayTakeDamage;
        _health.Died -= OnDie;
    }

    public void Initialize(Transform player)
    {
        _patrol = GetComponent<EnemyPatrol>();
        _vision = GetComponent<EnemyVision>();
        _attacker = GetComponent<EnemyAttacker>();
        _chaser = GetComponent<EnemyChaser>();
        _health = GetComponent<Health>();
        _flipper = GetComponentInChildren<Flipper>();
        _animator = GetComponentInChildren<CharacterAnimator>();
        _healthBarView = GetComponentInChildren<SmoothHealthBarView>();

        _animator.Initialize();
        _flipper.Initialize();
        _health.Initialize();
        _healthBarView.Initialize(_health);

        _patrol.Initialize(_flipper, _animator);
        _vision.Initialize(_flipper);
        _chaser.Initialize(_flipper, _animator);
        _attacker.Initialize(_animator);

        _health.Damaged += _animator.PlayTakeDamage;
        _health.Died += OnDie;
    }

    public void UpdateLogic()
    {
        if(_health.IsDead)
            return;

        if (_attacker.HasTarget())
        {
            _attacker.Attack();
            return;
        }

        if (_vision.TryGetPlayer(out Transform player))
        {
            _chaser.MoveTo(player);
            return;
        }

        _patrol.Patrol();
    }

    private void OnDie() 
    {
        _animator.SetSpeed(0f);
        _animator.PlayDie();
    }
}