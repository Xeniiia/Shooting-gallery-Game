using System;
using UnityEngine.Events;

namespace View
{
    public interface ITimerController
    {
        void SetTimeChangeHandler(UnityAction<float> action);
        void SetStartTimerHandler(UnityAction timerStart);
    }
}