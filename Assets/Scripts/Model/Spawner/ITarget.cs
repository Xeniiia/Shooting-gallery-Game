using UnityEngine;
using UnityEngine.Events;

namespace Model.Spawner
{
    public interface ITarget
    {
        UnityEvent EdgeTouched { get; }
        UnityEvent Clicked { get; }
        void Move(Vector3 pos);
    }
}