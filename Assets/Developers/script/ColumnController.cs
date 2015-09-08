using UnityEngine;
using System.Collections;

namespace Developers
{
    public class ColumnController : MonoBehaviour
    {
        public RectTransform boundaries;
        private float basePos;
        private float colSize;
        [HideInInspector]
        public float bottomBound;
        [HideInInspector]
        public float topBound;

        public void ForceStart()
        {
            Vector3[] corners = new Vector3[4];
            boundaries.GetWorldCorners(corners);

            float leftBound = corners[0].x;
            bottomBound = corners[0].y;
            float rightBound = corners[2].x;
            topBound = corners[2].y;

            float length = rightBound - leftBound;
			colSize = length / GlobalVars.COLUMNS_TOTAL;

            basePos = leftBound + colSize / 2;
        }

        public float GetIndexPos(int index)
        {
            return (colSize * index) + basePos;
        }

        public bool InColumnBounds(int index)
        {
            bool leftBounds = index >= 0;
			bool rightBounds = index < GlobalVars.COLUMNS_TOTAL;
            return leftBounds && rightBounds;
        }

        public bool InVertBounds(float pos, float buffer)
        {
            bool inBottomBound = pos >= bottomBound - buffer;
            bool inTopBound = pos <= topBound + buffer;
            return inBottomBound && inTopBound;
        }
    }
}
