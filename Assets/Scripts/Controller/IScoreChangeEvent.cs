using UnityEngine.Events;

namespace Controllers
{
    public interface IScoreChangeEvent
    {
        UnityEvent<int> ScoreChanged { get; }
    }
}