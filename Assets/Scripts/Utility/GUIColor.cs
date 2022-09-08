using System;
using UnityEngine;

namespace BWolf.UserInteraction.Utility
{
    public class GUIColor : IDisposable
    {
        private readonly Color _color;
        
        public GUIColor(Color color)
        {
           _color = GUI.color;
           GUI.color = color;
        }
        
        public void Dispose()
        {
            GUI.color = _color;
        }
    }
}
