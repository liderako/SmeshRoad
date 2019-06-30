using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;
using Trap.State;

namespace Trap
{
    public class BaseTrap : MonoBehaviour
    {
        [SerializeField] GameObject _ghost;
        [SerializeField] Animator _anim;
        protected IState    _state;
        protected bool _canActivate;
        protected bool _autoActivate;

        void Start()
        {
            //InitTrap(_state);
            ChangeState(_state);
        }

        void Update()
        {
            if (_anim.GetBool(0))
                _ghost.SetActive(true);
            else
                _ghost.SetActive(false);
        }
        public void ChangeState(IState state)
        {
            _state = state;
        }
        public void InitTrap(IState startState)
        {
            _canActivate = false;
            _autoActivate = false;
            _state = startState;
        }
    }
}