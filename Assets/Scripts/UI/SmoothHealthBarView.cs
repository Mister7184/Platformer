using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBarView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _changeSpeed = 1f;

    private Health _health;
    private Coroutine _changeRoutine;

    private void OnDisable()
    {
        _health.Changed -= UpdateView;
    }

    public void Initialize(Health health)
    {
        _health = health;
        _health.Changed += UpdateView;
        _health.Refresh();
    }

    private void UpdateView(int current, int max)
    {
        float targetValue = Normalize(current, max);

        if (_changeRoutine != null)
            StopCoroutine(_changeRoutine);

        _changeRoutine = StartCoroutine(ChangeValue(targetValue));
    }

    private IEnumerator ChangeValue(float targetValue) 
    {
        while (Mathf.Approximately(_slider.value, targetValue) == false) 
        {
            _slider.value = Mathf.MoveTowards(
                _slider.value, 
                targetValue, 
                _changeSpeed * Time.deltaTime);

            yield return null;
        }

        _slider.value = targetValue;
    }

    private float Normalize(int current, int max)
    {
        return (float)current / max;
    }
}
