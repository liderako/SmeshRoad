using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Sm;
        [SerializeField]private int _score;
        
        public delegate void MethodContainer(int score);
        public event MethodContainer ChangeScore; 
        
        public void Awake()
        {
            if (Sm == null)
            {
                Sm = this;
            }
        }

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                ChangeScore(_score);
            }
        }
    }
}
