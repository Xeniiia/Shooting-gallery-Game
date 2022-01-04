using UnityEngine;

namespace Model.PositionDetermination.Invertion.Directions
{
    public class HorizontalInvertionPosition : InvertionPosition
    {
        protected override Vector3 GetDirection(Vector3 vector)
        {
            return new Vector3(-vector.x, vector.y, vector.z);
        }
    }
}