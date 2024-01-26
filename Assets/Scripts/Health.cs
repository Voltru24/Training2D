using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action HealthChanged;


    [SerializeField] private float _value;
    [SerializeField] private float _valueMax;

    public float ValueMax => _valueMax;
    public float Value => _value;

    public void AddHealth(float value)
    {
        _value += value;

        if (_value > _valueMax)
        {
            _value = _valueMax;
        }

        HealthChanged?.Invoke();
    }

    public void TakeDamage(float value)
    {
        _value -= value;

        if (_value <= 0)
        {
            Kill();
        }

        HealthChanged?.Invoke();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
