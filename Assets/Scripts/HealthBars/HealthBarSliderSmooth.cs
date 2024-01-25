using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarSliderSmooth : MonoBehaviour
{
    private Slider _slider;

    [SerializeField] private int _barMaxValue = 100;
    [SerializeField] private float _speed = 5;

    private float _healthMax = 100;
    private float _health = 100;

    private void Start()
    {
        _slider = GetComponent<Slider>();

        _slider.maxValue = _barMaxValue;

        _slider.value = Mathf.Lerp(_slider.minValue, _slider.maxValue, _health / _healthMax);
    }

    private void FixedUpdate()
    {
        ShowInfo();
    }

    public void SetHealthMax(int value)
    {
        _healthMax = value;
    }

    public void TakeHealt(int value)
    {
        _health += value;

        if (_healthMax < _health)
        {
            _health = _healthMax;
        }
    }

    public void TakeDamage(int value)
    {
        _health -= value;

        if (_health < 0)
        {
            _health = 0;
        }
    }

    private void ShowInfo()
    {
        float lerp = Mathf.Lerp(_slider.minValue, _slider.maxValue, _health / _healthMax);

        _slider.value = Mathf.MoveTowards(_slider.value, lerp, _speed * Time.deltaTime);
    }
}
