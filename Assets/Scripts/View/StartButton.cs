using UnityEngine;

namespace View
{
    public class StartButton : MonoBehaviour, IButtonCallback
    {
        private IPlayController controller;

        private void Start()
        {
            controller = Controllers.Controller.Instance;
        }

        public void OnPlayHandler()
        {
            controller.Play(this);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}