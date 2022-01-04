using Model.Spawner.Spawners.Event;
using Model.Targets.Starters.Target;
using UnityEngine;
using UnityEngine.Events;

namespace Model.BonusLogic
{
    public class BonusSystem : MonoBehaviour, IBonusFillEvent, IBonusChange, Controllers.IBonusChange
    {
        [SerializeField] private int maxScoreForBonus = 5;
        private int scoreBonus = 0;
        public UnityEvent BonusFilled { get; private set; }
        public UnityEvent<int> BonusChanged { get; private set; }
        private int ScoreBonus
        {
            get => scoreBonus;
            set
            {
                if (value >= maxScoreForBonus || value < 0) scoreBonus = 0;
                else scoreBonus = value;
                BonusChanged.Invoke(scoreBonus);
                BonusFilledCheck(value);
            }
        }

        private void BonusFilledCheck(int value)
        {
            if (value >= maxScoreForBonus)
            {
                BonusFilled.Invoke();
            }
        }

        private void Awake()
        {
            BonusFilled = new UnityEvent();
            BonusChanged = new UnityEvent<int>();
        }

        public void AddBonusScore()
        {
            ScoreBonus++;
        }

        public void RemoveBonusScore()
        {
            ScoreBonus--;
        }
    }
}