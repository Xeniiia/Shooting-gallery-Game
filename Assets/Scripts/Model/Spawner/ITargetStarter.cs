using UnityEngine;

namespace Model.Spawner
{
    public interface ITargetStarter
    {
        void InitHandler(ITarget target);
        void LaunchTarget(Vector3 pos, ITarget target);
    }
}