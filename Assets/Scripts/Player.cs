using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _scoreMoney = 0;

    [SerializeField] private float _healthMax = 10;
    [SerializeField] private float _health = 10;

    public void AddMoney(int value)
    {
        _scoreMoney += value;
    }

    public void AddHealth(int value)
    {
        _health += value;

        if (_health > _healthMax)
        {
            _health = _healthMax;
        }
    }

    public void TakeDamage(float value)
    {
        _health -= value;

        if (_health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
