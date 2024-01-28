using System.Collections;
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
            StartCoroutine(DetainVampirism());

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

                StartCoroutine(DetainAttack());

                _isAttackTimer = true;
            }
        }
    }

    private void Attack()
    {
        Health health = _enemy.GetComponent<Health>();

        if(_isVampirism == true)
        {
            float forceVampirism = Mathf.Clamp(_forceAttack, 0, health.Value);

            _healthPlayer.AddHealth(forceVampirism);
        }

        health.TakeDamage(_forceAttack);
    }

    private IEnumerator DetainVampirism()
    {
        yield return new WaitForSeconds(_timeVampirism);

        _isVampirism = false;
    }

    private IEnumerator DetainAttack()
    {
        yield return new WaitForSeconds(_speedAttack);

        _isAttackTimer = false;
    }
}
