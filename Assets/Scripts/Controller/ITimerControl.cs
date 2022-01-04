using UnityEngine.Events;

namespace Controllers
{
    public interface ITimerControl
    {
        void StartTimer();
        void StopTimer();
        UnityEvent TimerStarted { get; }
        UnityEvent<float> TimeChanged { get; }
    }
}