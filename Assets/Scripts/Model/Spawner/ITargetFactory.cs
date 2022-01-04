using UnityEngine;

namespace Model.Spawner
{
    public interface ITargetFactory
    {
        ITarget GetTarget(Transform parent);
    }
}