using UnityEngine.Events;

namespace View
{
    public interface IGameOverController
    {
        void SetWinHandler(UnityAction action);
        void SetLoseHandler(UnityAction action);
    }
}