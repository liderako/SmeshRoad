using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AliveObject.Enemy.State;
using Interface;

namespace AliveObject.Enemy
{
    public class Enemy : AliveObject
    {
        [SerializeField] protected AttackState _attackState;
        [SerializeField] protected EnemyRunState _runState;
        [SerializeField] protected EnemyDeathState _deathState;
        public void Start()
        {
            _runState.BaseInit(_speed, _direction);
            _state = _runState;
            base.Start();
        }
    }
}