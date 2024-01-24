using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMoney : MonoBehaviour
{
    [SerializeField] private Money _money;

    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private int _countSpanwn;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        List<Transform> tempList = new List<Transform>(_spawnPoints);

        for (int i = 0; i < _countSpanwn; i++)
        {
            int index = Random.Range(0, tempList.Count);

            if (tempList.Count != 0)
            {
                Instantiate(_money, tempList[index]);

                tempList.RemoveAt(index);
            }
        }
    }
}
