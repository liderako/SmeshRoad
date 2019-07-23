using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AliveObject.State;
using Interface;
using Managers;

namespace AliveObject.Player
{
    public class Player : AliveObject
    {
        #region Inspector Var

        [SerializeField] protected RunState _runState;
        [SerializeField] protected DeathState _deathState;

        #endregion

        #region Unity Methods

        public void Start()
        {
            GameManager.Gm.StartGame += StartGame;
            FinishManager.FM.Finish += FinishGame;
            LevelManager.LM.Clear += Clear;
            PlayerManager.PM.SpawnAlivePlayer();
            GetComponent<DeathState>().AliveObjectDead += LevelManager.LM.DeadPlayer;
            ChangeState(gameObject.AddComponent<StayState>());
        }

        #endregion

        #region Private Methods

        private void StartGame()
        {
            _speed = Resources.Load<Settings>("Settings/Settings").SpeedBasePlayer;
            _direction = Resources.Load<Settings>("Settings/Settings").DirectionMainMove;
            _runState.BaseInit(_speed, _direction);
            ChangeState(_runState);
        }

        private void FinishGame()
        {
            ChangeState(gameObject.GetComponent<StayState>());
        }

        private void Clear()
        {
            ChangeState(_deathState);
        }

        #endregion
    }
}