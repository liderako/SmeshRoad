using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;

namespace Trap.State
{
    public class ActivateState : MonoBehaviour, IState
    {
        BaseTrap _owner;
        DeactivateState _deactivateState;
        Animator _animator;
        bool _canActivate;


        public void BaseInit(BaseTrap trap, Animator anim)
        {
            _animator = anim;
            _owner = trap;
            _deactivateState = GetComponent<DeactivateState>();
        }
        public void UpdateState()
        {
            _animator.SetBool("activate", true);
        }
        public void EndAnim()
        {
            _animator.SetBool("activate", false);
            _owner.ChangeState(_deactivateState);
        }

    }
}