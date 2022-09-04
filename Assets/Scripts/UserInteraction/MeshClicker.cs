using UnityEngine;

namespace BWolf.UserInteraction
{
    public class MeshClicker : MonoBehaviour
    {
        private Camera _camera;
        
        [RuntimeInitializeOnLoadMethod]
        private static void OnLoad()
        {
            GameObject gameObject = new GameObject("~MeshClicker");
            gameObject.AddComponent<MeshClicker>();
            
            DontDestroyOnLoad(gameObject);
        }

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
                return;
            
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Debug.Log($"Hit {hitInfo.transform.name}");
            }
        }
    }
}
