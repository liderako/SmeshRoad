using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager PM;
    public int _amountAlive;

    public void Awake()
    {
        if (PM == null)
        {
            PM = this;
        }
    }

    public void SpawnAlivePlayer()
    {
        _amountAlive += 1;
    }

    public void DeadPlayer()
    {
        _amountAlive -= 1;
        if (_amountAlive == 0 && GameManager.Gm.IsGame)
        {
            GameManager.Gm.IsGame = false;
        }
    }

    public int AmountAlive => _amountAlive;
}
