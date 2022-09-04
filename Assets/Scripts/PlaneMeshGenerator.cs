using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWolf.MeshGeneration
{
    public class PlaneMeshGenerator : MeshGenerator
    {
        protected override Vector3[] GetVertices() => new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 0, 1),
            new Vector3(0, 0, 1)
        };

        protected override int[] GetTriangles() => new int[]
        {
            1, 0, 3,
            1, 3, 2
        };
    }
}