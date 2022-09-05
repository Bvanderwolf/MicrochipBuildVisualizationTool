using System;
using UnityEngine;

namespace BWolf.MeshGeneration
{
    /// <summary>
    /// Represents a mono behaviour that can generate a mesh.
    /// It requires a MeshFilter and MeshRenderer component to work.
    /// </summary>
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public abstract class MeshGenerator : MeshGeneratorBase
    {
        /// <summary>
        /// Whether the generated mesh should be interactable.
        /// </summary>
        [SerializeField]
        private bool _interactable;
        
        /// <summary>
        /// A reference to the mesh filter wrapped inside the lazy class.
        /// This makes it so it also works when it is used inside the editor.
        /// </summary>
        private readonly Lazy<MeshFilter> _filter;
        
        /// <summary>
        /// A reference to the mesh filter wrapped inside the lazy class.
        /// This makes it so it also works when it is used inside the editor.
        /// </summary>
        private readonly Lazy<MeshRenderer> _renderer;

        /// <summary>
        /// Sets up the lazy filter class with a reference to the
        /// function that gets the mesh filter component.
        /// </summary>
        protected MeshGenerator()
        {
            _filter = new Lazy<MeshFilter>(GetComponent<MeshFilter>);
            _renderer = new Lazy<MeshRenderer>(GetComponent<MeshRenderer>);
        }
        
        /// <summary>
        /// Adds a box collider component to the game object
        /// if the generator is set to be interactable.
        /// </summary>
        private void Awake()
        {
            if (_interactable)
                gameObject.AddComponent<BoxCollider>();
        }

        /// <summary>
        /// Should return the vertices for the mesh.
        /// </summary>
        /// <returns>The vertices.</returns>
        protected abstract Vector3[] GetVertices();

        /// <summary>
        /// Should return the triangles for the mesh.
        /// </summary>
        /// <returns>The triangles.</returns>
        protected abstract int[] GetTriangles();

        /// <summary>
        /// Sets the mesh to be interactable or not by adding/removing a collider.
        /// </summary>
        /// <param name="value">The new interactable value.</param>
        public void SetInteractable(bool value)
        {
            if (value == _interactable)
                return;

            if (value)
                gameObject.AddComponent<BoxCollider>();
            else
                Destroy(GetComponent<BoxCollider>());

            _interactable = value;
        }
        
        /// <summary>
        /// Generates the mesh using the abstract functions.
        /// </summary>
        /// <param name="material">The material to set for the mesh.</param>
        public override void GenerateMesh(Material material = null)
        {
            Mesh mesh = GetMesh();
            Vector3[] vertices = GetVertices();
            int[] triangles = GetTriangles();
         
            mesh.Clear();
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.Optimize();
            mesh.RecalculateNormals();

            if (material != null)
                _renderer.Value.material = material;
        }

        /// <summary>
        /// Returns the mesh for generation, accounting for whether the
        /// application is in editor mode or play mode.
        /// </summary>
        /// <returns></returns>
        private Mesh GetMesh()
        {
            MeshFilter filter = _filter.Value;
            if (Application.isPlaying)
                return filter.mesh;

            // Returns the shared mesh if its not null, otherwise the shared mesh with a newly assigned value.
            return filter.sharedMesh ?? (filter.sharedMesh = new Mesh());
        }
    }
}