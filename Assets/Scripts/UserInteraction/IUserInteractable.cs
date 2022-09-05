using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWolf.UserInteraction
{
    public interface IUserInteractable
    {
        bool IsHovered { get; }

        void OnHoverStart();

        void OnHoverEnd();

        void OnClick();
    }
}