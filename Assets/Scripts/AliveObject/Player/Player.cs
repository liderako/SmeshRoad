using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AliveObject.State;
using Interface;

namespace AliveObject.Player
{
    public class Player : AliveObject
    {
        [SerializeField] protected RunState _runState;
        [SerializeField] protected DeathState _deathState;
        public void Start()
        {
            _runState.BaseInit(_speed, _direction);
            _state = _runState;
            base.Start();
        }

        private void Update()
        {
            _state.UpdateState();
        }

        public void ChangeUpdate(IState state)
        {
            _state = state;
        }
    }
}