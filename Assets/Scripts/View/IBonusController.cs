using UnityEngine.Events;

namespace View
{
    public interface IBonusController
    {
        void SetBonusChangeHandler(UnityAction<int> action);
    }
}