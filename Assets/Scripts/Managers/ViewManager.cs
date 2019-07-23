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
        //[SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI textNumberLevel;
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
            textNumberLevel.text = "Level " + GameManager.Gm.Level;
        }

        private void InitEvent()
        {
            //ScoreManager.Sm.ChangeScore += UpdateScore;
            GameManager.Gm.StartGame += RenderGameUI;
            GameManager.Gm.GameOver += RenderGameOverUI;
            GameManager.Gm.Clear += Clear;
            GameManager.Gm.GameFinish += RenderFinishUI;
        }

        private void UpdateScore(int score)
        {
           // scoreText.text = score.ToString();
        }

        private void RenderGameUI()
        {
            textStart.enabled = false;
            textNumberLevel.text = "Level " + GameManager.Gm.Level;
        }
        
        private void RenderGameOverUI()
        {
            textGameOver.enabled = true;
        }

        public void RenderFinishUI()
        {
            textNumberLevel.text = "LEVEL " + GameManager.Gm.Level + " COMPLETE";
        }

        private void DeactivateUI()
        {
            textStart.enabled = true;
            textGameOver.enabled = false;
        }

        private void Clear()
        {
            textNumberLevel.text = "Level " + GameManager.Gm.Level;
            DeactivateUI();
        }
    }
}
