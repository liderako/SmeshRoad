using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class ViewManager : MonoBehaviour
    {
        public static ViewManager Vm;
        [SerializeField] private TextMeshProUGUI textStart;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI textGameOver;
        
        public void Awake()
        {
            if (Vm == null)
            {
                Vm = this;
            }
            DeactivateUI();
        }

        public void Start()
        {
            InitEvent();
        }

        private void InitEvent()
        {
            ScoreManager.Sm.ChangeScore += UpdateScore;
            GameManager.Gm.StartGame += RenderStartUI;
            GameManager.Gm.GameOver += RenderGameOverUI;
        }

        private void UpdateScore(int score)
        {
            scoreText.text = score.ToString();
        }

        private void RenderStartUI()
        {
            textStart.enabled = false;
            scoreText.enabled = true;
        }
        
        private void RenderGameOverUI()
        {
            textGameOver.enabled = true;
            scoreText.enabled = false;
        }

        private void DeactivateUI()
        {
            textStart.enabled = true;
            scoreText.enabled = false;
            textGameOver.enabled = false;
        }
    }
}
