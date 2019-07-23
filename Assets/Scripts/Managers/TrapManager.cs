using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Trap;
namespace Managers
{
    public class TrapManager : MonoBehaviour
    {
        public static TrapManager TM;
        private BaseTrap _activeTrap;
        public void Awake()
        {
            if (TM == null)
            {
                TM = this;
            }
            else
            {
                Destroy(this);
            }
        }

        public void ChangeActiveTrap(BaseTrap trap)
        {
            if (_activeTrap != null)
            {
                _activeTrap.TriggerOff();
            }
            trap.TriggerOn();
            _activeTrap = trap;
        }

        public BaseTrap ActiveTrap => _activeTrap;
    }
}
