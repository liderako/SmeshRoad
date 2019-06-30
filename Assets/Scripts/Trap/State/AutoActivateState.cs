using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;

namespace Trap.State
{
    public class AutoActivateState : MonoBehaviour, IState
    {
        BaseTrap            _owner;
        ActivateState   _activateState;
        WaitState       _waitState;
        bool            _autoActivate;


        public void BaseInit(ref bool autoActivate, BaseTrap trap)
        {
            _autoActivate = autoActivate;
            _owner = trap;
            _activateState = GetComponent<ActivateState>();
            _waitState = GetComponent<WaitState>();
        }
        public void UpdateState()
        {
            if (_autoActivate)
                _owner.ChangeState(_activateState);

        }

        private void OnMouseUp()
        {
            _owner.ChangeState(_waitState);
        }
    }
}