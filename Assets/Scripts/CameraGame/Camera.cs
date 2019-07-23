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
        private Vector3 _positionOrigin;
        
        public void Start()
        {
            _positionOrigin = transform.position;
            _speed = Resources.Load<Settings>("Settings/Settings").SpeedMain;
            _dir = Resources.Load<Settings>("Settings/Settings").DirectionMainMove;
            _runState = gameObject.AddComponent<RunState>();
            ChangeState(gameObject.AddComponent<StayState>());
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
            GameManager.Gm.StartGame += MoveCamera;
            GameManager.Gm.GameOver += StopCamera;
            GameManager.Gm.Clear += Clear;
            GameManager.Gm.GameFinish += StopCamera;
        }
        
        private void StopCamera()
        {
            Debug.Log("Stop camera");
            ChangeState(gameObject.GetComponent<StayState>());
        }

        private void MoveCamera()
        {
            Debug.Log("Camera Move");
            _runState.BaseInit(_speed, _dir);
            ChangeState(_runState);
        }

        private void Clear()
        {
            Debug.Log("Camera Clear");
            ChangeState(gameObject.GetComponent<StayState>());
            transform.position = _positionOrigin;
        }
    }
}
