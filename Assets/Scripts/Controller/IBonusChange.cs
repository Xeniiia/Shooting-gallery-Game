using UnityEngine.Events;

namespace Controllers
{
    public interface IBonusChange
    {
        UnityEvent<int> BonusChanged { get; }
    }
}