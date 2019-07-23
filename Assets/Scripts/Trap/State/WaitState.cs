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
        bool            _active;

        private void Start()
        {
            _active = false;
            _canActivate = false;
        }
        public void BaseInit(bool canActivate, BaseTrap trap)
        {
            _canActivate = false;
            _canActivate = canActivate;
            _owner = trap;
            _activateState = GetComponent<ActivateState>();
        }
  
        public void UpdateState()
        {
            _active = false;
            if(Input.GetMouseButton(0))
            {
                Activate();

            }
        }

        public void Activate()
        {
            if (_canActivate && !_active)
            {
                _owner.ChangeState(_activateState);
                _active = true;
            }
        }
    }
}