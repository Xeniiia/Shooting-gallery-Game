using System;
using UnityEngine;
using UnityEngine.Events;
using View;

namespace Controllers
{
    public class Controller : MonoBehaviour, IGameOverController, ITimerController, IScoreController, IBonusController, IPlayController
    {
        private IWinEvent[] _winEvent;
        private ILoseEvent[] _loseEvent;
        private IScoreChangeEvent _scoreChangeEvent;
        private IBonusChange _bonusChange;
        private ISpawnerControl[] _spawnerControl;
        private ITimerControl _timerControl;
        private static Controller _instance;
        public static Controller Instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = this;
            _winEvent = GetComponentsInChildren<IWinEvent>() ?? throw new NullReferenceException();
            _loseEvent = GetComponentsInChildren<ILoseEvent>() ?? throw new NullReferenceException();
            _bonusChange = GetComponentInChildren<IBonusChange>() ?? throw new NullReferenceException();
            _scoreChangeEvent = GetComponentInChildren<IScoreChangeEvent>() ?? throw new NullReferenceException();
            _spawnerControl = GetComponentsInChildren<ISpawnerControl>() ?? throw new NullReferenceException();
            _timerControl = GetComponentInChildren<ITimerControl>() ?? throw new NullReferenceException();
        }

        public void SetLoseHandler(UnityAction action)
        {
            foreach (var @event in _loseEvent)
            {
                @event.Losed.AddListener(action);
                @event.Losed.AddListener(Stop);
            }
        }

        public void SetWinHandler(UnityAction action)
        {
            foreach (var @event in _winEvent)
            {
                @event.Wined.AddListener(action);
                @event.Wined.AddListener(Stop);
            }
        }

        private void Stop()
        {
            foreach (var spawner in _spawnerControl)
            {
                spawner.StopSpawn();
            }
            _timerControl.StopTimer();
        }

        public void SetTimeChangeHandler(UnityAction<float> action)
        {
            _timerControl.TimeChanged.AddListener(action);
        }

        public void SetScoreChangedHandler(UnityAction<int> action)
        {
            _scoreChangeEvent.ScoreChanged.AddListener(action);
        }

        public void SetBonusChangeHandler(UnityAction<int> action)
        {
            _bonusChange.BonusChanged.AddListener(action);
        }

        public void SetStartTimerHandler(UnityAction action)
        {
            _timerControl.TimerStarted.AddListener(action);
        }

        public void Play(IButtonCallback sender)
        {
            _timerControl.StartTimer();
            foreach (var spawner in _spawnerControl)
            {
                spawner.StartSpawn();
            }
            sender.Disable();
        }
    }
}