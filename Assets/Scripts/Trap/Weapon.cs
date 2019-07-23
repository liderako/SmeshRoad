using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;
using AliveObject.State;
using AliveObject;

public class Weapon : MonoBehaviour
{
    GameObject _victim;
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<AliveObject.AliveObject>() != null)
        {
            _victim = other.gameObject;
            Attack();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AliveObject.AliveObject>() != null)
        {
            _victim = other.gameObject;
            Attack();
        }
    }

    void Attack()
    {
        DeathState _vicDeath = _victim.GetComponent<DeathState>();
        AliveObject.AliveObject _vicObj = _victim.GetComponent<AliveObject.AliveObject> ();
        _vicObj.ChangeState(_vicDeath);
    }
}
