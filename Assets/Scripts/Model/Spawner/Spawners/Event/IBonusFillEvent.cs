using UnityEngine.Events;

namespace Model.Spawner.Spawners.Event
{
    public interface IBonusFillEvent
    {
        UnityEvent BonusFilled { get; }
    }
}