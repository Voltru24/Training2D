using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _scoreMoney = 0;

    public void AddMoney(int value)
    {
        _scoreMoney += value;
    }
}
