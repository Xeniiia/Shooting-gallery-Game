using UnityEngine;
using System;
using Model.Spawner;

namespace Model.Targets.Starters.Bonus
{
    public class BonusStarter : MonoBehaviour, ITargetStarter
    {
        [SerializeField] private int addTimeForBonus = 3;
        private IAddTime _timer;

        private void Awake()
        {
            var controller = transform.parent;
            _timer = controller.GetComponentInChildren<IAddTime>() ?? throw new NullReferenceException();
        }

        public void InitHandler(ITarget target)
        {
            target.Clicked.AddListener(() =>
            {
                _timer.AddTime(addTimeForBonus);
            });
        }

        public void LaunchTarget(Vector3 pos, ITarget target)
        {
            target.Move(pos);
        }
    }
}