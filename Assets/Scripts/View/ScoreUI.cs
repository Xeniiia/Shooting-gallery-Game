using System;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        private IScoreController controller;

        private void Start()
        {
            controller = Controllers.Controller.Instance;
            controller.SetScoreChangedHandler(ViewScore);
        }

        private void ViewScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}
