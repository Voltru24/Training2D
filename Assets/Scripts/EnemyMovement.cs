using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private List<Transform> _routePoints;
        
    private int _indexRoute = 0;

    private void FixedUpdate()
    {
        int epsilon = 1;

        if (Vector3.Distance(_routePoints[_indexRoute].position, transform.position) < epsilon)
        {
            _indexRoute++;

            if (_indexRoute >= _routePoints.Count)
            {
                _indexRoute = 0;
            }
        }

        Move();
    }

    private void Move()
    {
        Vector3 direction = (_routePoints[_indexRoute].position - transform.position).normalized;

        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
