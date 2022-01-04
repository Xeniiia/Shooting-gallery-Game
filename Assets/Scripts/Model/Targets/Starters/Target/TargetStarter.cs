using Model.Spawner;
using System;
using UnityEngine;

namespace Model.Targets.Starters.Target
{
    public class TargetStarter : MonoBehaviour, ITargetStarter
    {
        private IScoreCounter _scoreCounter;
        private IBonusChange _bonusSystem;
        private Transform parent;

        private void Awake()
        {
            parent = transform.parent;
            _scoreCounter = parent.GetComponentInChildren<IScoreCounter>() ?? throw new NullReferenceException();
            _bonusSystem = parent.GetComponentInChildren<IBonusChange>() ?? throw new NullReferenceException();
        }

        public void InitHandler(ITarget target)
        {
            target.Clicked.AddListener(() =>
            {
                _scoreCounter.AddScore();
                _bonusSystem.AddBonusScore();
            });
            target.EdgeTouched.AddListener(() =>
            {
                _scoreCounter.RemoveScore();
                _bonusSystem.RemoveBonusScore();
            });
        }

        public void LaunchTarget(Vector3 pos, ITarget target)
        {
            target.Move(pos);
        }
    }
}