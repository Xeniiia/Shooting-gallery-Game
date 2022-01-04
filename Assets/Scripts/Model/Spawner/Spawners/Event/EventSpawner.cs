using System;

namespace Model.Spawner.Spawners.Event
{
    public class EventSpawner : Spawner
    {
        private IBonusFillEvent _bonusSystem;

        protected override void Init()
        {
            var controller = transform.parent;
            _bonusSystem = controller.GetComponentInChildren<IBonusFillEvent>() ?? throw new NullReferenceException();
        }

        public override void StartSpawn()
        {
            _bonusSystem.BonusFilled.AddListener(base.StartSpawn);
        }

        public override void StopSpawn()
        {
            _bonusSystem.BonusFilled.RemoveListener(base.StartSpawn);
        }
    }
}