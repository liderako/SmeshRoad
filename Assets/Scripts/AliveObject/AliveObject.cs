using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AliveObject.State;
using Interface;

namespace AliveObject
{
    public class AliveObject : MonoBehaviour
    {
        protected IState _state;
        [SerializeField] protected float _speed;
        [SerializeField] protected Vector3 _direction;


        protected void Start()
        {
            ChangeState(_state);
        }

        void Update()
        {
            _state.UpdateState();
        }

        public void ChangeState(IState state)
        {
            _state = state;
        }
    }
}