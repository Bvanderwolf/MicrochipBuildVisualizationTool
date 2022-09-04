using System;
using UnityEngine;

namespace BWolf.MeshGeneration
{
   [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
   public class CubeMeshGenerator : MeshGenerator
   {
      [SerializeField]
      private Vector3 _size = Vector3.one;

      protected override Vector3[] GetVertices() => new Vector3[]
      {
         new Vector3(0, 0, 0),
         new Vector3(_size.x, 0, 0),
         new Vector3(_size.x, _size.y, 0),
         new Vector3(0, _size.y, 0),
         new Vector3(0, _size.y, _size.z),
         new Vector3(_size.x, _size.y, _size.z),
         new Vector3(_size.x, 0, _size.z),
         new Vector3(0, 0, _size.z)
      };
      
      /// <summary>
      /// Returns triangles in order: front, top, right, left, back, bottom
      /// </summary>
      /// <returns></returns>
      protected override int[] GetTriangles() => new int[]
      {
         0, 2, 1,
         0, 3, 2,
         2, 3, 4,
         2, 4, 5,
         1, 2, 5,
         1, 5, 6,
         0, 7, 4,
         0, 4, 3,
         5, 4, 7,
         5, 7, 6,
         0, 6, 7,
         0, 1, 6
      };
   }
}
