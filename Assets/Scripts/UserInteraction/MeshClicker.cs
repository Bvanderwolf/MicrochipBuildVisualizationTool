using UnityEngine;

namespace BWolf.UserInteraction
{
    public class MeshClicker : MonoBehaviour
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponentInParent<Canvas>().worldCamera ?? Camera.main;
        }

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
