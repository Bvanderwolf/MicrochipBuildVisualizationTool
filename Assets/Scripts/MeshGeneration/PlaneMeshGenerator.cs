using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWolf.MeshGeneration
{
    public class PlaneMeshGenerator : MeshGenerator
    {
        [SerializeField]
        private Vector2 _size = Vector3.one;
        
        protected override Vector3[] GetVertices() => new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(_size.x, 0, 0),
            new Vector3(_size.x, 0, _size.y),
            new Vector3(0, 0, _size.y)
        };

        protected override int[] GetTriangles() => new int[]
        {
            1, 0, 3,
            1, 3, 2
        };
    }
}