using System;
using UnityEngine;

namespace BWolf.UserInteraction.Utility
{
    public class GizmoColor : IDisposable
    {
        private readonly Color _color;
        
        public GizmoColor(Color color)
        {
            _color = Gizmos.color;
            Gizmos.color = color;
        }
        
        public void Dispose()
        {
            Gizmos.color = _color;
        }
    }
}

