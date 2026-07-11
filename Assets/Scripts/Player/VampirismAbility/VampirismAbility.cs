using System.Collections;
using UnityEngine;

[RequireComponent(typeof(VampirismHealthDrainer))]

public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _cooldown = 4f;

    private PlayerVision _playerVision;
    private VampirismHealthDrainer _healthDrainer;
    private VampirismView _view;
    private VampirismBarView _barView;

    private Coroutine _abilityRoutine;

    private void OnDisable()
    {
        if (_abilityRoutine != null)
        {
            StopCoroutine(_abilityRoutine);
            _abilityRoutine = null;
        }

        if (_view != null)
            _view.Hide();

        if (_barView != null)
            _barView.SetValue(1f);
    }

    public void Initialize(Health ownerHealth, PlayerVision playerVision)
    {
        _playerVision = playerVision;

        _healthDrainer = GetComponent<VampirismHealthDrainer>();
        _view = GetComponentInChildren<VampirismView>();
        _barView = GetComponentInChildren<VampirismBarView>();

        _healthDrainer.Initialize(ownerHealth);
        _barView.Initialize();

        _view.Hide();
    }

    public void TryActivate()
    {
        if (_abilityRoutine != null)
            return;

        _abilityRoutine = StartCoroutine(AbilityRoutine());
    }

    private IEnumerator AbilityRoutine()
    {
        yield return UseAbility();
        yield return Recharge();

        _barView.SetValue(1f);
        _abilityRoutine = null;
    }

    private IEnumerator UseAbility()
    {
        _view.Show();
        _healthDrainer.Reset();

        float remainingTime = _duration;

        while (remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;

            if (_playerVision.TryGetClosestEnemy(out Health target))
                _healthDrainer.Drain(target);

            float progress = remainingTime / _duration;
            _barView.SetValue(progress);

            yield return null;
        }

        _barView.SetValue(0f);
        _view.Hide();
    }


    private IEnumerator Recharge()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _cooldown)
        {
            elapsedTime += Time.deltaTime;

            float progress = elapsedTime / _cooldown;
            _barView.SetValue(progress);

            yield return null;
        }
    }
}
