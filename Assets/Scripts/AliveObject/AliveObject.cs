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
        [SerializeField] protected float _minSpeedAnimation = 0.7f;
        [SerializeField] protected float _maxSpeedAnimation = 1.5f;

        private void Awake()
        {
            GetComponent<Animator>().speed = Random.Range(_minSpeedAnimation, _maxSpeedAnimation);
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