using Model.Spawner;
using System.Collections.Generic;
using UnityEngine;

namespace Model.PositionDetermination.Invertion
{
    public abstract class InvertionPosition : MonoBehaviour, ITargetPositions
    {
        public Dictionary<int, int> CreateTargetPositions(List<Transform> spawns)
        {
            spawns = CreateInvertionTransforms(spawns, out var newTransforms);
            Dictionary<int, int> invertionTarget = InitRelationship(spawns, newTransforms);
            return invertionTarget;
        }

        private Dictionary<int, int> InitRelationship(List<Transform> spawns, Transform[] newTransforms)
        {
            Dictionary<int, int> invertionTarget = new Dictionary<int, int>();
            int halfPositionsLength = spawns.Count / 2;
            for (int i = 0; i < halfPositionsLength; i++)
            {
                int inverti = spawns.FindIndex(x => newTransforms[i] == x);     //TODO: вернуться и осознать что тут происходит
                invertionTarget[i] = inverti;
                invertionTarget[inverti] = i;
            }
            return invertionTarget;
        }

        private List<Transform> CreateInvertionTransforms(List<Transform> spawns, out Transform[] newTransforms)
        {
            newTransforms = new Transform[spawns.Count];
            for (int i = 0; i < spawns.Count; i++)
            {
                var position = spawns[i].position;
                newTransforms[i] = CreateGameObject(GetDirection(position), "InvertTarget" + (i + 1));
            }
            spawns.AddRange(newTransforms);
            return spawns;
        }

        protected abstract Vector3 GetDirection(Vector3 vector);

        private Transform CreateGameObject(Vector3 position, string name)
        {
            var newTransform = new GameObject(name).transform;
            newTransform.position = position;
            return newTransform;
        }
    }
}