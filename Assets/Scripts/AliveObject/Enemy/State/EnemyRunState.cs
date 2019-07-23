using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AliveObject.State;
using AliveObject.Player;

namespace AliveObject.Enemy.State
{
    public class EnemyRunState : RunState
    {
        AttackState _attackState;
        Enemy _owner;

        public void BaseInit(float speed, Vector3 direction)
        {
            base.BaseInit(speed, direction);
            _attackState = gameObject.GetComponent<AttackState>();
            _owner = gameObject.GetComponent<Enemy>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Player.Player>() != null) //Attack
            {
                _attackState.BaseInit(collision.gameObject);
                _owner.ChangeState(_attackState);
            }
        }
    }
}