using BWolf.UserInteraction;
using UnityEngine;

namespace BWolf.Meshes.Generation
{
    /// <summary>
    /// Generates a plane mesh.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlaneMeshGenerator : MeshGenerator, IUserInteractable
    {
        /// <summary>
        /// The color of the plane when hovered over.
        /// </summary>
        [SerializeField]
        private Color _hoverColor;

        /// <summary>
        /// The color of the plane when selected.
        /// </summary>
        [SerializeField]
        private Color _selectedColor;
        
        /// <summary>
        /// The size of the plane, where x=width, y=length.
        /// </summary>
        [SerializeField]
        private Vector2 _size = Vector3.one;

        /// <summary>
        /// The size of the plane, where x=width, y=length.
        /// </summary>
        public Vector2 Size
        {
            get => _size;
            set => _size = value;
        }

        /// <summary>
        /// The color of the mesh when hovered over.
        /// </summary>
        public Color HoveredColor
        {
            get => _hoverColor;
            set => _hoverColor = value;
        }

        /// <summary>
        /// The color of the mesh when selected.
        /// </summary>
        public Color SelectedColor
        {
            get => _selectedColor;
            set => _selectedColor = value;
        }

        /// <summary>
        /// The initial color of the generated mesh.
        /// </summary>
        private Color _color;

        protected override void Awake()
        {
            base.Awake();

            Rigidbody body = GetComponent<Rigidbody>();
            body.useGravity = false;
            body.isKinematic = true;
        }

        /// <summary>
        /// Makes sure operations after mesh generation are called
        /// as a mesh might already be generated in the editor.
        /// </summary>
        private void Start() =>  OnGeneratedMesh();

        /// <summary>
        /// The vertices for the plane.
        /// </summary>
        /// <returns>The vertices.</returns>
        protected override Vector3[] GetVertices() => new Vector3[]
        {
            new Vector3(-(_size.x * 0.5f), 0, -(_size.y * 0.5f)),
            new Vector3(_size.x * 0.5f, 0, -(_size.y * 0.5f)),
            new Vector3(_size.x * 0.5f, 0, _size.y * 0.5f),
            new Vector3(-(_size.x * 0.5f), 0, _size.y * 0.5f)
        };

        // 000, sizeX00, sizeX0sizeY, 00sizeY
        
        /// <summary>
        /// The triangles for the plane.
        /// </summary>
        /// <returns>The triangles.</returns>
        protected override int[] GetTriangles() => new int[]
        {
            1, 0, 3,
            1, 3, 2
        };

        /// <summary>
        /// Stores the initial color of the material used for the mesh.
        /// </summary>
        protected override void OnGeneratedMesh()
        {
            _color = _renderer.Value.material.color;
        }
        
        /// <summary>
        /// Sets the color of the mesh to the hovered color.
        /// </summary>
        public void OnHoverStart()
        {
            _renderer.Value.material.color = _hoverColor;
        }
        
        /// <summary>
        /// Resets the color of the mesh to the initial color.
        /// </summary>
        public void OnHoverEnd()
        {
            ResetColor();
        }

        public void OnSelect()
        {
            _renderer.Value.material.color = _selectedColor;
        }

        public void OnDeselect()
        {
            ResetColor();
        }

        public void OnClick()
        {
            Debug.Log($"{name} was clicked.");
        }

        private void ResetColor()
        {
            _renderer.Value.material.color = _color;
        }
    }
}