using UnityEngine.Events;

namespace Controllers
{
    public interface IWinEvent
    {
        UnityEvent Wined { get; }
    }
}