using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;

namespace Trap.State
{
    public class WaitState : MonoBehaviour, IState
    {
        BaseTrap            _owner;
        ActivateState   _activateState;
        bool            _canActivate;


        public void BaseInit(ref bool canActivate, BaseTrap trap)
        {
            _canActivate = canActivate;
            _owner = trap;
            _activateState = GetComponent<ActivateState>();
        }
        public void UpdateState()
        {

        }

        private void OnMouseUp()
        {
            if (_canActivate)
                _owner.ChangeState(_activateState);
        }
    }
}