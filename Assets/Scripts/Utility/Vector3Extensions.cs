using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWolf.UserInteraction.Utility
{
    public static class Vector3Extensions
    {
        public static Vector3 Average(this IEnumerable<Vector3> vectors)
        {
            Vector3 average = Vector3.zero;
            int count = 0;

            foreach (Vector3 vector3 in vectors)
            {
                average += vector3;
                count++;
            }

            return average / count;
        }
        
        public static float ShortestDistance(this Vector3 position, IEnumerable<Vector3> positions)
        {
            float smallestSqrMagnitude = float.MaxValue;

            foreach (Vector3 p in positions)
            {
                float sqrMagnitude = (p - position).sqrMagnitude;
                if (sqrMagnitude < smallestSqrMagnitude)
                    smallestSqrMagnitude = sqrMagnitude;
            }

            return Mathf.Sqrt(smallestSqrMagnitude);
        }
        
        public static Vector2 Average(this IEnumerable<Vector2> vectors)
        {
            Vector2 average = Vector2.zero;
            int count = 0;

            foreach (Vector2 vector3 in vectors)
            {
                average += vector3;
                count++;
            }

            return average / count;
        }
        
        public static float ShortestDistance(this Vector2 position, IEnumerable<Vector2> positions)
        {
            float smallestSqrMagnitude = float.MaxValue;

            foreach (Vector2 p in positions)
            {
                float sqrMagnitude = (p - position).sqrMagnitude;
                if (sqrMagnitude < smallestSqrMagnitude)
                    smallestSqrMagnitude = sqrMagnitude;
            }

            return Mathf.Sqrt(smallestSqrMagnitude);
        }
    }
}
