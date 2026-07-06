using UnityEngine;

[RequireComponent(typeof(Flipper), typeof(EnemyPatrol), typeof(EnemyVision))]
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
        _flipper = GetComponent<Flipper>();
        _patrol = GetComponent<EnemyPatrol>();
        _vision = GetComponent<EnemyVision>();
        _attacker = GetComponent<EnemyAttacker>();
        _chaser = GetComponent<EnemyChaser>();
        _health = GetComponent<Health>();
        _animator = GetComponentInChildren<CharacterAnimator>();
        _healthBarView = GetComponentInChildren<SmoothHealthBarView>();

        _animator.Initialize();
        _flipper.Initialize();
        _health.Initialize();
        _healthBarView.Initialize(_health);

        _patrol.Initialize(_flipper, _animator);
        _vision.Initialize(_flipper);
        _chaser.Initialize(player, _flipper, _animator);
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

        if (_vision.CanSeePlayer() || _vision.CanHearPlayer()) 
        {
            _chaser.UpdateLogic();
            return;
        }

        _patrol.UpdateLogic();
    }

    private void OnDie() 
    {
        _animator.SetSpeed(0f);
        _animator.PlayDie();
    }
}