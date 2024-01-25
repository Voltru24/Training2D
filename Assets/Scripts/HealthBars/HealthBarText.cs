using TMPro;
using UnityEngine;
[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthBarText : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private int _healthMax = 100;
    private int _health = 100;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();

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
        _text.text = $"{_health} / {_healthMax} ";
    }
}
