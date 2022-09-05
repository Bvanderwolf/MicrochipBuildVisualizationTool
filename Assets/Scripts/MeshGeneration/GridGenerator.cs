using UnityEngine;

namespace BWolf.MeshGeneration
{
    public class GridGenerator : MeshGeneratorBase
    {
        [SerializeField]
        private Material _material;
        
        [SerializeField]
        private Vector2 _gridSize = new Vector2(2, 2);

        [SerializeField]
        private Vector2 _planeSize = new Vector2(1, 1);
        
        private void OnValidate()
        {
            if (_gridSize.x < 2)
                _gridSize.x = 2;
            if (_gridSize.y < 2)
                _gridSize.y = 2;

            if (_planeSize.x < 1)
                _planeSize.x = 1;
            if (_planeSize.y < 1)
                _planeSize.y = 1;
        }

        public override void GenerateMesh(Material material = null)
        {
            // regenerate child objects based on grid size.
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                if (Application.isEditor)
                    DestroyImmediate(transform.GetChild(i).gameObject);
                else
                    Destroy(transform.GetChild(i).gameObject);
            }

            Vector3 localPosition = Vector3.zero;
            for (int z = 0; z < _gridSize.y; z++)
            {
                for (int x = 0; x < _gridSize.x; x++)
                {
                    localPosition.x = (x * _planeSize.x);
                    localPosition.z = (z * _planeSize.y);
                    
                    GameObject child = new GameObject($"Plane ({1 + (z + x)})");
                    child.transform.SetParent(transform);
                    child.transform.localPosition = localPosition;
                    
                    PlaneMeshGenerator generator = child.AddComponent<PlaneMeshGenerator>();
                    generator.Size = _planeSize;
                    generator.GenerateMesh(_material);
                    generator.SetInteractable(true);
                }
            }
        }
    }
}