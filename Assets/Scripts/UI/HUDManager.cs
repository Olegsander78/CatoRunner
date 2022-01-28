using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private int _scoreTotal;



    public void AddScore(int amount)
    {
        _scoreTotal += amount;
    }

    public void AddHealth(int amount)
    {

    }

    public void AddSpeedUp()
    {

    }

    public void AddInvulnerability()
    {

    }

}
