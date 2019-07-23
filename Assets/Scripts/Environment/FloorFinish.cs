using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class FloorFinish : MonoBehaviour
{
    public void Start()
    {
        LevelManager.LM.Clear += Clear;
    }

    private void Clear()
    {
        Destroy(gameObject);
    }
}
