using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using AliveObject.Player;
using UnityEngine;

namespace Managers
{
    public class FinishManager : MonoBehaviour
    {
        public delegate void MethodContainer();

        public event MethodContainer Finish;

        public static FinishManager FM;

        public int _finishedPlayer;
        private bool isFinish;
        
        public void Awake()
        {
            if (FM == null)
            {
                FM = this;
            }
        }

        public void Start()
        {
            GameManager.Gm.Clear += Clear;
        }

        public void addFinishedPlayer()
        {
            _finishedPlayer += 1;
            if (!isFinish && _finishedPlayer == PlayerManager.PM.AmountAlive)
            {
                isFinish = true;
                Finish();
            }
        }

        public void Clear()
        {
            _finishedPlayer = 0;
            isFinish = false;
        }
    }
}