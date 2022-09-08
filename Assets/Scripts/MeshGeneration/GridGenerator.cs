using UnityEngine;

namespace BWolf.MeshGeneration
{
    /// <summary>
    /// Manages a grid of plane generators.
    /// </summary>
    public class GridGenerator : MeshGeneratorBase
    {
        /// <summary>
        /// The color of the planes when hovered over.
        /// </summary>
        [SerializeField]
        private Color _hoverColor;

        /// <summary>
        /// The color of the planes when selected.
        /// </summary>
        [SerializeField]
        private Color _selectedColor;
        
        /// <summary>
        /// The material used for the planes in the grid.
        /// </summary>
        [SerializeField]
        private Material _material;
        
        /// <summary>
        /// The size of the grid determining the amount of planes.
        /// </summary>
        [SerializeField]
        private Vector2Int _gridSize = new Vector2Int(2, 2);

        /// <summary>
        /// The size of the planes in the grid.
        /// </summary>
        [SerializeField]
        private Vector2 _planeSize = new Vector2(1, 1);
        
        /// <summary>
        /// Ensures the sizes don't fall under an impossible value.
        /// </summary>
        private void OnValidate()
        {
            if (_gridSize.x < 2)
                _gridSize.x = 2;
            if (_gridSize.y < 2)
                _gridSize.y = 2;

            if (_planeSize.x < 0)
                _planeSize.x = 1;
            if (_planeSize.y < 0)
                _planeSize.y = 1;
        }

        /// <summary>
        /// Generates the grid mesh by creating the planes as child objects.
        /// </summary>
        public override void GenerateMesh(Material material = null)
        {
            // First destroy all existing child objects.
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                if (Application.isEditor)
                    DestroyImmediate(transform.GetChild(i).gameObject);
                else
                    Destroy(transform.GetChild(i).gameObject);
            }

            // Create new plane child objects based on grid and panel sizes. 
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
                    generator.HoveredColor = _hoverColor;
                    generator.SelectedColor = _selectedColor;
                    generator.GenerateMesh(_material);
                    generator.SetInteractable(true);
                }
            }
        }
    }
}