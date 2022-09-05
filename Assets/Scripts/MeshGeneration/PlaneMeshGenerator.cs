using BWolf.UserInteraction;
using UnityEngine;

namespace BWolf.MeshGeneration
{
    /// <summary>
    /// Generates a plane mesh.
    /// </summary>
    public class PlaneMeshGenerator : MeshGenerator, IUserInteractable
    {
        /// <summary>
        /// The color of the plane when hovered over.
        /// </summary>
        [SerializeField]
        private Color _hoverColor;
        
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

        public Color HoveredColor
        {
            get => _hoverColor;
            set => _hoverColor = value;
        }

        private Color _color;

        private void Start()
        {
            OnGeneratedMesh();
        }

        /// <summary>
        /// The vertices for the plane.
        /// </summary>
        /// <returns>The vertices.</returns>
        protected override Vector3[] GetVertices() => new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(_size.x, 0, 0),
            new Vector3(_size.x, 0, _size.y),
            new Vector3(0, 0, _size.y)
        };

        /// <summary>
        /// The triangles for the plane.
        /// </summary>
        /// <returns>The triangles.</returns>
        protected override int[] GetTriangles() => new int[]
        {
            1, 0, 3,
            1, 3, 2
        };

        protected override void OnGeneratedMesh()
        {
            _color = _renderer.Value.material.color;
        }

        public bool IsHovered => _renderer.Value.material.color == _hoverColor;
        
        public void OnHoverStart()
        {
            _renderer.Value.material.color = _hoverColor;
        }

        public void OnHoverEnd()
        {
            _renderer.Value.material.color = _color;
        }

        public void OnClick()
        {
            Debug.Log($"{name} was clicked.");
        }
    }
}