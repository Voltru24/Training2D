using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int _forceAttack = 1;
    [SerializeField] private float _speedAttack = 2f;
    [SerializeField] private float _timeVampirism = 6f;
    [SerializeField] private Health _healthPlayer;
    [SerializeField] private KeyCode _keyVampirism;

    private bool _isGoal = false;
    private Enemy _enemy;
    private bool _isAttackTimer = false;
    private bool _isVampirism = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            _enemy = collision.GetComponent<Enemy>();

            _isGoal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {  
            _isGoal = false;
        }
    }

    private void Update()
    {
        if (Input.GetKey(_keyVampirism))
        {
            Invoke(nameof(VampirismTimer), _timeVampirism);

            _isVampirism = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isGoal == true)
        {
            if (_isAttackTimer == false)
            {
                Attack();

                Invoke(nameof(AttackTimer), _speedAttack);

                _isAttackTimer = true;
            }
        }
    }

    private void Attack()
    {
        Health health = _enemy.GetComponent<Health>();

        if(_isVampirism == true)
        {
            float tempHealth = health.Value;
            float forceVampirism = _forceAttack;

            if (tempHealth < forceVampirism)
            {
                tempHealth -= forceVampirism;

                forceVampirism += tempHealth;
            }

            _healthPlayer.AddHealth(forceVampirism);
        }

        health.TakeDamage(_forceAttack);
    }

    private void VampirismTimer()
    {
        _isVampirism = false;
    }

    private void AttackTimer()
    {
        _isAttackTimer = false;
    }
}
