using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _healthMax = 10;
    [SerializeField] private int _health = 10;

    [SerializeField] private HealthBar[] _healthBars;

    private void Start()
    {
        ShowInfo();
    }

    public void AddHealth(int value)
    {
        _health += value;

        if (_health > _healthMax)
        {
            _health = _healthMax;
        }

        ShowInfo();
    }

    public void TakeDamage(int value)
    {
        _health -= value;

        if (_health <= 0)
        {
            _health = 0;
        }

        ShowInfo();
    }

    private void ShowInfo()
    {
        foreach (HealthBar healthBar in _healthBars)
        {
            healthBar.ShowHealth(_health, _healthMax);
        }
    }
}
