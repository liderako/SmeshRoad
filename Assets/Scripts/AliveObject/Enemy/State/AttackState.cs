using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AliveObject.Player;
using Interface;
using AliveObject.State;

namespace AliveObject.Enemy.State
{
    public class AttackState : MonoBehaviour, IState
    {
        GameObject _victim; // жертва
        Enemy _owner;
        EnemyRunState _runState;

        public void BaseInit(GameObject victim)
        {
            _victim = victim;
            _owner = GetComponent<Enemy>();
            _runState = GetComponent<EnemyRunState>();
        }

        public void UpdateState()
        {
            Attack();
        }

        void Attack()
        {
            DeathState _vicDeath = _victim.GetComponent<DeathState>();
            Player.Player _vicObj = _victim.GetComponent<Player.Player>();
            _vicObj.ChangeState(_vicDeath);
			_owner.ChangeState(_runState);
        }
    }
}