using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private Text gameOverText;
        private IGameOverController controller;

        private void Start()
        {
            controller = Controllers.Controller.Instance;
            controller.SetLoseHandler(Losed);
            controller.SetWinHandler(Wined);
        }

        private void Losed()
        {
            gameOverText.text = "Game Over.";
        }

        private void Wined()
        {
            gameOverText.text = "Win!";
        }
    }
}