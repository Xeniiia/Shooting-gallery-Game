using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private Image timeLine;
        private float maxTime = 30;
        private ITimerController controller;


        private void Start()
        {
            controller = Controllers.Controller.Instance;
            controller.SetStartTimerHandler(OnStartTimer);
            controller.SetTimeChangeHandler(OnSetTime);
        }

        private void OnSetTime(float t)
        {
            timeLine.fillAmount = ToProcent(t, maxTime);
        }
        private float ToProcent(float t, float maxTime)
        {
            float oneProcent = maxTime / 100;
            float procent = t / oneProcent;
            return procent / 100;
        }

        private void OnStartTimer()
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

    }
}
