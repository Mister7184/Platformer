using UnityEngine;
using UnityEngine.UI;

public class VampirismBarView : MonoBehaviour
{
    [SerializeField] Slider _slider;

    public void Initialize() 
    {
        _slider.minValue = 0f;
        _slider.maxValue = 1f;
        _slider.value = 1f;
    }

    public void SetValue(float value) 
    {
        _slider.value = Mathf.Clamp01(value);
    }
}
