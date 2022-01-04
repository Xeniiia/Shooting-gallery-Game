using System;
using System.Collections;
using UnityEngine;

namespace Model.Spawner.Spawners.Time
{
    public class TimeSpawner : Spawner
    {
        private float _startTime = 0;
        private Coroutine startSpawnerCoroutine;

        public override void StartSpawn()
        {
            startSpawnerCoroutine = StartCoroutine(TimeSpawn(base.StartSpawn));
        }

        public override void StopSpawn()
        {
            StopCoroutine(startSpawnerCoroutine);
        }

        private IEnumerator TimeSpawn(Action randomSpawn)
        {
            yield return new WaitForSeconds(_startTime);

            while (true)
            {
                randomSpawn();
                yield return new WaitForSeconds(2);
            }
        }
    }
}