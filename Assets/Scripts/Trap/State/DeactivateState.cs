using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;

namespace Trap.State
{
    public class DeactivateState : MonoBehaviour, IState
    {
        [SerializeField] int _waitToDead;
        BaseTrap _owner;
        WaitState _waitState;
        Animator _animator;
        bool _canActivate;

        public void UpdateState()
        {
            _animator.SetBool("activate", false);
//            Debug.Log("DEAD");
          //  StartCoroutine(DeleteTrap());
        }
        public void BaseInit(ref bool canActivate, BaseTrap trap, Animator anim)
        {
            _animator = anim;
            _canActivate = canActivate;
            _owner = trap;
            _waitState = GetComponent<WaitState>();
        }
        
        IEnumerator DeleteTrap()
        {
            yield return new WaitForSeconds(_waitToDead);
            gameObject.SetActive(false);
            _canActivate = false;
            _owner.ChangeState(_waitState);
            //Переносим обратно в пул
        }
    }
}