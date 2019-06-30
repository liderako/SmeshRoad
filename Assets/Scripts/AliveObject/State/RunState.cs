using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;

namespace AliveObject.State
{
    public class RunState : MonoBehaviour, IState
    {
        private float _speed;
        private Vector3 _direction;

        public void BaseInit(float speed, Vector3 direction)
        {
            _speed = speed;
            _direction = direction;
        }

        public void UpdateState()
        {
            transform.position += _direction * _speed * Time.deltaTime;
        }
    }
}