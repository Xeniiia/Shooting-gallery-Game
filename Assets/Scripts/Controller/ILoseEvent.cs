using UnityEngine.Events;

namespace Controllers
{
    public interface ILoseEvent
    {
        UnityEvent Losed { get; }
    }
}