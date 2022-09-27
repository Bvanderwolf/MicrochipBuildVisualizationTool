using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWolf.UserInteraction.Utility
{
    public static class TransformExtensions
    {
        public static void ReplaceParent(this Transform transform, Transform other)
        {
            Transform parent = transform.parent;
            other.SetParent(parent);
            transform.SetParent(other);
        }
    }
}
