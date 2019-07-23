using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]private bool _isGame;

        public static GameManager Gm;
        
        public delegate void MethodContainer();
        public event MethodContainer GameOver;
        public event MethodContainer StartGame;
        public event MethodContainer Clear;
        public event MethodContainer GameFinish;

        #region Private Properties

        private int _level;
        private bool _isGameOver;
        private bool _levelComplete;

        #endregion
        public void Awake()
        {
            if (Gm == null)
            {
                Gm = this;
            }
            PlayerPrefs.DeleteAll();
            _level = PlayerPrefs.GetInt("level", 1);
            
        }

        public void Start()
        {
            FinishManager.FM.Finish += LevelComplete;
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0) && !_isGame && !_isGameOver && !_levelComplete)
            {
                if (StartGame != null)
                {
                    _isGame = true;
                    Debug.Log("Start game, event");
                    StartGame();
                }
            }
            if (_levelComplete && Input.GetMouseButtonDown(0))
            {
                NextLevel();
            }
        }

        public bool IsGame
        {
            get => _isGame;
            set
            {
                _isGame = value;
                if (_isGame == false)
                {
                    _isGameOver = true;
                    if (GameOver != null)
                    {
                        Debug.Log("Game over, event");
                        GameOver();
                    }
                }
            }
        }

        public void LevelComplete()
        {
            _level++;
            PlayerPrefs.SetInt("level", _level);
            _levelComplete = true;
            GameFinish();
        }

        private void NextLevel()
        {
            Debug.Log("Clear game, event");
            _levelComplete = false;
            _isGame = false;
            _isGameOver = false;
            Clear();
        }

        public int Level => _level;
    }
}