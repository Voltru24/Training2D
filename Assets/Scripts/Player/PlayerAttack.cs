using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int _forceAttack = 1;
    [SerializeField] private float _speedAttack = 2f;

    private bool _isGoal = false;
    private Enemy _enemy;
    private bool isAttackTimer = false;

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

    private void FixedUpdate()
    {
        if (_isGoal == true)
        {
            if (isAttackTimer == false)
            {
                Attack();

                Invoke(nameof(AttackTimer), _speedAttack);

                isAttackTimer = true;
            }
        }
    }

    private void Attack()
    {
        Health health = _enemy.GetComponent<Health>();

        health.TakeDamage(_forceAttack);
    }

    private void AttackTimer()
    {
        isAttackTimer = false;
    }
}
