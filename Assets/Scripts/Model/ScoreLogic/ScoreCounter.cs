using Model.Targets.Starters.Target;
using Controllers;
using UnityEngine;
using UnityEngine.Events;

namespace Model.ScoreLogic
{
    public class ScoreCounter : MonoBehaviour, IScoreCounter, IScoreChangeEvent, IWinEvent, ILoseEvent
    {
        [SerializeField] private int maxScore = 20;
        [SerializeField] private int startScore = 10;
        private int score;
        private int Score
        {
            get => score;
            set
            {
                score = value;
                ScoreChanged.Invoke(score);
                if (score == 0)
                {
                    Losed.Invoke();
                }
                else if (score == maxScore)
                {
                    Wined.Invoke();
                }
            }
        }


        public UnityEvent<int> ScoreChanged { get; private set; }
        public UnityEvent Losed { get; private set; }
        public UnityEvent Wined { get; private set; }

        private void Awake()
        {
            ScoreChanged = new UnityEvent<int>();
            Losed = new UnityEvent();
            Wined = new UnityEvent();
        }

        private void Start()
        {
            Score = startScore;
        }

        public void AddScore()
        {
            Score++;
        }

        public void RemoveScore()
        {
            Score--;
        }

    }
}