using System.Collections;
using System.Collections.Generic;
using AliveObject.Enemy;
using UnityEngine;
using Interface;
using Managers;

namespace Trap
{
    public class Trigger : MonoBehaviour
    {
        [SerializeField] BaseTrap _owner;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Enemy>() != null)
            {
                TrapManager.TM.ChangeActiveTrap(_owner);
            }
        }
    }
}