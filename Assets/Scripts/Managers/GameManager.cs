using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
     
        [SerializeField]private bool _isGame;
        private bool _isGameOver;
        
        public static GameManager Gm;
        
        public delegate void MethodContainer();
        public event MethodContainer GameOver;
        public event MethodContainer StartGame;
        
        public void Awake()
        {
            if (Gm == null)
            {
                Gm = this;
            }
        }

        public bool IsGame
        {
//            get => _isGame;
            set
            {
                _isGame = value;
                if (_isGame == false)
                {
                    _isGameOver = true;
                    if (GameOver != null)
                    {
                        GameOver();
                    }
                }
            }
        }

        public void Update()
        {
            if (Input.GetMouseButton(0) && !_isGame && !_isGameOver)
            {
                if (StartGame != null)
                {
                    _isGame = true;
                    StartGame();
                }
            }
        }
    }
}