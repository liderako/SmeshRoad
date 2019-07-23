using System.Collections;
using System.Collections.Generic;
using AliveObject.Enemy;
using AliveObject.State;
using Managers;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            GameObject enemy = collision.gameObject;
            DeathState _vicDeath = enemy.GetComponent<DeathState>();
            AliveObject.AliveObject _vicObj = enemy.GetComponent<AliveObject.AliveObject> ();
            _vicObj.ChangeState(_vicDeath);
        }
    }
}
