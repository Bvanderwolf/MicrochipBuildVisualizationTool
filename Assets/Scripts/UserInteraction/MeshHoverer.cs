using UnityEngine;

namespace BWolf.UserInteraction
{
    /// <summary>
    /// Interacts with behaviours in the scene that implement the <see cref="IUserInteractable"/>
    /// when the user hovers over them with the mouse.
    /// </summary>
    public class MeshHoverer : MonoBehaviour
    {
        /// <summary>
        /// The previous mouse position used to check
        /// whether the mouse position has changed.
        /// </summary>
        private Vector3 _previousMousePosition;
        
        /// <summary>
        /// The camera reference used for ray casting.
        /// </summary>
        private Camera _camera;

        /// <summary>
        /// The currently hovered over interactable implementation.
        /// </summary>
        private IUserInteractable _currentInteractable;
        
        /// <summary>
        /// Sets the camera reference.
        /// </summary>
        private void Awake()
        {
            _camera = Camera.main;
        }
        
        /// <summary>
        /// Interacts with user interactable implementations in the scene if
        /// the user has changed the mouse position on screen.
        /// </summary>
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
                if (_currentInteractable != null)
                {
                    _currentInteractable.OnHoverEnd();
                    _currentInteractable = null;
                }
                
                return;
            }
            
            // Retrieve the user interactable implementation but do nothing if it can't be found.
            IUserInteractable interactable = hitInfo.transform.GetComponent<IUserInteractable>();
            if (interactable == null)
            {
                // Call back to the hoverable implementation that it stopped the hover,
                // since we are now hitting a different object.
                if (_currentInteractable != null)
                {
                    _currentInteractable.OnHoverEnd();
                    _currentInteractable = null;
                }

                return;
            }

            // Call back to the hoverable implementation that it stopped,
            // if the interactable hit is not the same as the one saved.
            if (_currentInteractable != null && interactable != _currentInteractable)
                _currentInteractable.OnHoverEnd();

            _currentInteractable = interactable;
            _currentInteractable.OnHoverStart();
        }
    }
}
