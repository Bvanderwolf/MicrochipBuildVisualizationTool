using UnityEngine;

namespace BWolf.UserInteraction
{
    /// <summary>
    /// Interacts with behaviours in the scene that have collision and implement
    /// the <see cref="IUserInteractable"/> interface.
    /// </summary>
    public class MeshClicker : MonoBehaviour
    {
        /// <summary>
        /// The camera used for sending raycasts from.
        /// </summary>
        private Camera _camera;

        /// <summary>
        /// Sets the camera reference.
        /// </summary>
        private void Awake()
        {
            _camera = Camera.main;
        }

        /// <summary>
        /// Interacts with user interactable interface implementations in
        /// the scene if the user pressed the left mouse button.
        /// </summary>
        private void Update()
        {
            // If the user does not press the left mouse button down, do nothing.
            if (!Input.GetMouseButtonDown(0))
                return;
            
            // If the user pressed the left mouse button but not on an object, do nothing.
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit hitInfo)) 
                return;
            
            IUserInteractable interactable = hitInfo.transform.GetComponent<IUserInteractable>();
            interactable?.OnClick();
        }
    }
}
