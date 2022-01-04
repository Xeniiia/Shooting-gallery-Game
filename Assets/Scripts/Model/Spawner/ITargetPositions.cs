using System.Collections.Generic;
using UnityEngine;

namespace Model.Spawner
{
    public interface ITargetPositions
    {
        Dictionary<int, int> CreateTargetPositions(List<Transform> spawnPositions);
    }
}