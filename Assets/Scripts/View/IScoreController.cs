using UnityEngine.Events;

namespace View
{
    public interface IScoreController
    {
        void SetScoreChangedHandler(UnityAction<int> action);
    }
}