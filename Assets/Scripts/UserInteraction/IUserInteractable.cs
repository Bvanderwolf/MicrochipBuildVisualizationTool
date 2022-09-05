using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWolf.UserInteraction
{
    /// <summary>
    /// Is used by mesh generators to make their generated meshes interactable
    /// with the user. 
    /// </summary>
    public interface IUserInteractable
    {
        /// <summary>
        /// Whether the mesh is being hovered over.
        /// </summary>
        bool IsHovered { get; }

        /// <summary>
        /// Invoked when the hovering of the mesh has started.
        /// </summary>
        void OnHoverStart();

        /// <summary>
        /// Invoked when the hovering of the mesh has stopped.
        /// </summary>
        void OnHoverEnd();

        /// <summary>
        /// Invoked when the mesh has been clicked.
        /// </summary>
        void OnClick();
    }
}