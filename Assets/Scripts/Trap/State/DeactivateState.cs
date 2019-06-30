using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;

namespace Trap.State
{
    public class DeactivateState : MonoBehaviour, IState
    {
        [SerializeField] int _waitToDead;
        public void UpdateState()
        {
            StartCoroutine(DeleteTrap());
        }
        IEnumerator DeleteTrap()
        {
            yield return new WaitForSeconds(_waitToDead);
            //Переносим обратно в пул
        }
    }
}