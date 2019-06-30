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
        bool _canActivate;


        public void BaseInit(BaseTrap trap)
        {
            _owner = trap;
            _deactivateState = GetComponent<DeactivateState>();
        }
        public void UpdateState()
        {
            // что-то делает

        }
        public void EndAnim()
        {
            _owner.ChangeState(_deactivateState);
        }
    }
}