using System.Collections;
using System.Collections.Generic;
using AliveObject.State;
using UnityEngine;
using Managers;
using Interface;

namespace CameraGame
{
    public class Camera : MonoBehaviour
    {
        private IState _state;
        private float _speed;
        private Vector3 _dir;
        private RunState _runState;
        
        public void Start()
        {
            _speed = Resources.Load<Settings>("Settings/Settings").SpeedMain;
            _dir = Resources.Load<Settings>("Settings/Settings").DirectionMainMove;
            _runState = gameObject.AddComponent<RunState>();
            _runState.BaseInit(0, _dir);
            ChangeState(_runState);
            InitEvent();
        }

        void Update()
        {
            _state.UpdateState();
        }

        public void ChangeState(IState state)
        {
            _state = state;
        }
        
        private void InitEvent()
        {
            GameManager.Gm.StartGame += StartGame;
            GameManager.Gm.GameOver += GameEnd;
        }
        
        private void GameEnd()
        {
            _runState.BaseInit(0, _dir);
            ChangeState(_runState);
        }

        private void StartGame()
        {
            _runState.BaseInit(_speed, _dir);
            ChangeState(_runState);
        }
    }
}
