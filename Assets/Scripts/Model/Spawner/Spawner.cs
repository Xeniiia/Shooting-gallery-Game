using Controllers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Model.Spawner
{
    public class Spawner : MonoBehaviour, ISpawnerControl
    {
        private List<Transform> _spawnPositions;
        private Dictionary<int, int> _invertionTarget;
        private ITargetFactory _enemyFactory;
        private ITargetStarter _targetStarter;
        private ITargetPositions _targetPositions;

        private void Awake()
        {
            _spawnPositions = new List<Transform>(transform.GetComponentsInChildren<Transform>());
            _spawnPositions.RemoveAt(0);
            _targetPositions = GetComponent<ITargetPositions>() ?? throw new NullReferenceException();
            _enemyFactory = GetComponent<ITargetFactory>() ?? throw new NullReferenceException();
            _targetStarter = GetComponent<ITargetStarter>() ?? throw new NullReferenceException();
            Init();
        }

        private void Start()
        {
            _invertionTarget = _targetPositions.CreateTargetPositions(_spawnPositions);
        }

        protected virtual void Init() { }

        public virtual void StartSpawn()
        {
            RandomSpawn();
        }

        public virtual void StopSpawn() { }

        protected virtual ITarget GetTargetWithRandom(out int index)
        {
            index = UnityEngine.Random.Range(0, _spawnPositions.Count);
            return _enemyFactory.GetTarget(_spawnPositions[index]);
        }

        private void RandomSpawn()
        {
            var target = GetTargetWithRandom(out var index);
            _targetStarter.InitHandler(target);
            var indexPos = _invertionTarget[index];
            _targetStarter.LaunchTarget(_spawnPositions[indexPos].position, target);
        }
    }
}