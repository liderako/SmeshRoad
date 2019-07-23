using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AliveObject.Enemy.State;
using AliveObject.State;
using Interface;
using Managers;

namespace AliveObject.Enemy
{
    public class Enemy : AliveObject
    {
        [SerializeField] protected AttackState _attackState;
        [SerializeField] protected EnemyRunState _runState;
        [SerializeField] protected DeathState _deathState;

        public void Start()
        {
            GameManager.Gm.StartGame += StartGame;
            GameManager.Gm.GameOver += GameOver;
            FinishManager.FM.Finish += Clear;
            GetComponent<DeathState>().AliveObjectDead += LevelManager.LM.DeadEnemy;
            ChangeState(gameObject.AddComponent<StayState>());
        }

        private void StartGame()
        {
            _speed = Resources.Load<Settings>("Settings/Settings").SpeedBaseEnemy;
            _direction = Resources.Load<Settings>("Settings/Settings").DirectionMainMove;
            _runState.BaseInit(_speed, _direction);
            ChangeState(_runState);
        }

        private void GameOver()
        {
            ChangeState(gameObject.GetComponent<StayState>());
        }

        private void Clear()
        {
            ChangeState(_deathState);
        }
    }
}