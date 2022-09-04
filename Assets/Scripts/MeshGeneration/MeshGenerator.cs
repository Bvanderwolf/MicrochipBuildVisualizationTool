using System;
using UnityEngine;

namespace BWolf.MeshGeneration
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public abstract class MeshGenerator : MonoBehaviour
    {
        [SerializeField]
        private bool _interactable;
        
        private readonly Lazy<MeshFilter> _filter;

        protected MeshGenerator()
        {
            _filter = new Lazy<MeshFilter>(GetComponent<MeshFilter>);
        }

        private void Awake()
        {
            if (_interactable)
                gameObject.AddComponent<BoxCollider>();
        }

        private void Start()
        {
            GenerateMesh();
        }

        protected abstract Vector3[] GetVertices();

        protected abstract int[] GetTriangles();
        
        [ContextMenu("Generate")]
        public void GenerateMesh()
        {
            Mesh mesh = GetMesh();
            Vector3[] vertices = GetVertices();
            int[] triangles = GetTriangles();
         
            mesh.Clear();
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.Optimize();
            mesh.RecalculateNormals();
        }

        private Mesh GetMesh()
        {
            MeshFilter filter = _filter.Value;
            if (Application.isPlaying)
                return filter.mesh;

            return filter.sharedMesh ?? (filter.sharedMesh = new Mesh());
        }
    }
}