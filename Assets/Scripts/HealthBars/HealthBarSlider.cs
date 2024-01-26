using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarSlider: HealthBar
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public override void ShowHealth(float health, float healthMax)
    {
        _slider.value = Mathf.Lerp(_slider.minValue, _slider.maxValue, health / healthMax);
    }
}
