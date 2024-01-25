using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarSlider: MonoBehaviour
{
    private Slider _slider;

    [SerializeField] private int _barMaxValue = 100;

    private float _healthMax = 100;
    private float _health = 100;

    private void Start()
    {
        _slider = GetComponent<Slider>();

        _slider.maxValue = _barMaxValue;

        ShowInfo();
    }

    public void SetHealthMax(int value)
    {
        _healthMax = value;

        ShowInfo();
    }

    public void TakeHealt(int value)
    {
        _health += value;

        if (_healthMax < _health)
        {
            _health = _healthMax;
        }

        ShowInfo();
    }

    public void TakeDamage(int value)
    {
        _health -= value;

        if (_health < 0)
        {
            _health = 0;
        }
   
        ShowInfo();
    }

    private void ShowInfo()
    {
        _slider.value = Mathf.Lerp(_slider.minValue, _slider.maxValue, _health / _healthMax);
    }
}
