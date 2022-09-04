using System;
using UnityEngine;

namespace BWolf.MeshGeneration
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public abstract class MeshGenerator : MonoBehaviour
    {
        private MeshFilter _filter;
   
        private void Awake()
        {
            _filter = GetComponent<MeshFilter>();
        }
   
        private void Start()
        {
            GenerateMesh();
        }

        protected abstract Vector3[] GetVertices();

        protected abstract int[] GetTriangles();
        
        private void GenerateMesh()
        {
            Mesh mesh = _filter.mesh;
            Vector3[] vertices = GetVertices();
            int[] triangles = GetTriangles();
         
            mesh.Clear();
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.Optimize();
            mesh.RecalculateNormals();
        }
    }
}