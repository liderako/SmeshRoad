using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public void Start()
    {
        LevelManager.LM.Clear += Clear;
    }

    private void Clear()
    {
        LevelManager.LM.ReturnFloor(gameObject);
    }
}
