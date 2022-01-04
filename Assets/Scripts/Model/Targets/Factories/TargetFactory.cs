using Model.Spawner;
using UnityEngine;

namespace Model.Targets.Factories
{
    public class TargetFactory : MonoBehaviour, ITargetFactory
    {
        [SerializeField] private Target[] targets;

        public ITarget GetTarget(Transform parent = null)
        {
            int targetIndex = Random.Range(0, targets.Length);
            var target = Instantiate(targets[targetIndex], parent);
            return target;
        }
    }
}