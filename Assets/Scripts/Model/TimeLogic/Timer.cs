using Model.Targets.Starters.Bonus;
using Controllers;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Model.TimeLogic
{
    public class Timer : MonoBehaviour, ILoseEvent, IAddTime, ITimerControl
    {
        [SerializeField] private float maxTime = 30f;
        [SerializeField] private float startTime = 30f;
        private Coroutine timerCoroutine;
        public UnityEvent Losed { get; private set; }
        public UnityEvent<float> TimeChanged { get; private set; }
        public UnityEvent TimerStarted { get; private set; }
        private float time;
        private float FloatTime
        {
            get => time;
            set
            {
                time = value;
                TimeChanged.Invoke(time);
                if (time < 0)
                {
                    Losed.Invoke();
                }
            }
        }

        private void Awake()
        {
            Losed = new UnityEvent();
            TimeChanged = new UnityEvent<float>();
            TimerStarted = new UnityEvent();
        }

        public void StartTimer()
        {
            TimerStarted.Invoke();
            FloatTime = startTime;
            timerCoroutine = StartCoroutine(CountDownTime());
        }

        private IEnumerator CountDownTime()
        {
            while (FloatTime > 0)
            {
                FloatTime -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            yield break;
        }

        public void StopTimer()
        {
            StopCoroutine(timerCoroutine);
        }

        public void AddTime(int time)
        {
            FloatTime += time;
        }
    }
}