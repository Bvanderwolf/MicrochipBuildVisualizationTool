using System;
using UnityEngine;

namespace BWolf.UserInteraction
{
    public class MeshHoverer : MonoBehaviour
    {
        private Vector3 _previousMousePosition;
        
        private Camera _camera;

        private IUserInteractable _hoverable;

        private void Awake()
        {
            _camera = GetComponentInParent<Canvas>().worldCamera ?? Camera.main;
        }
        
        private void Update()
        {
            Vector3 mousePosition = Input.mousePosition;
            
            // If the mouse position on screen did not move, do nothing.
            if (_previousMousePosition == mousePosition)
                return;

            // If the mouse is not hovering over an object, do nothing.
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                // Call back to the hoverable implementation that it stopped the hover.
                if (_hoverable != null)
                {
                    _hoverable.OnHoverEnd();
                    _hoverable = null;
                }
                
                return;
            }
            
            // Retrieve the user interactable implementation but do nothing if it can't be found.
            IUserInteractable interactable = hitInfo.transform.GetComponent<IUserInteractable>();
            if (interactable == null)
            {
                // Call back to the hoverable implementation that it stopped the hover,
                // since we are now hitting a different object.
                if (_hoverable != null)
                {
                    _hoverable.OnHoverEnd();
                    _hoverable = null;
                }

                return;
            }

            // Call back to the hoverable implementation that it stopped,
            // if the interactable hit is not the same as the one saved.
            if (_hoverable != null && interactable != _hoverable)
                _hoverable.OnHoverEnd();

            _hoverable = interactable;
            _hoverable.OnHoverStart();
        }
    }
}
