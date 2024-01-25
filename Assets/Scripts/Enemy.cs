using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedAttack;

    [SerializeField] private float _distanceAttack = 1f;

    [SerializeField] private int _forceAttack = 1;

    [SerializeField] private List<Transform> _routePoints;

    [SerializeField] private int _health = 2;

    private int _indexRoute = 0;

    private bool _isGoal = false;
    private bool isAttackTimer = false;
    private Transform _goal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            _goal = collision.GetComponent<Transform>();
            _isGoal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            _isGoal = false;
        }
    }

    private void FixedUpdate()
    {
        int epsilon = 1;

        if (_isGoal == true)
        {
            if (Vector3.Distance(_goal.position, transform.position) <= _distanceAttack)
            {
                if (isAttackTimer == false)
                {
                    Invoke(nameof(AttackTimer), _speedAttack);

                    Attack();

                    isAttackTimer = true;
                }
            }

            Move(_goal);
        }
        else
        {
            if (Vector3.Distance(_routePoints[_indexRoute].position, transform.position) < epsilon)
            {
                _indexRoute = ++_indexRoute % _routePoints.Count;
            }

            Move(_routePoints[_indexRoute]);
        }
    }

    public void TakeDamage(int value)
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

    private void Move(Transform goal)
    {
        Vector3 direction = (goal.position - transform.position).normalized;

        transform.Translate(direction * _speedMove * Time.deltaTime);
    }

    private void Attack()
    {
        Player player = _goal.GetComponent<Player>();

        player.TakeDamage(_forceAttack);

        isAttackTimer = false;
    }

    private void AttackTimer()
    {
        isAttackTimer = false;
    }
}
