using UnityEngine;

namespace BWolf.Meshes.Generation
{
   /// <summary>
   /// Generates the mesh for a cube.
   /// </summary>
   public class CubeMeshGenerator : MeshGenerator
   {
      /// <summary>
      /// The size of the cube where x=width, y=height, z=length.
      /// </summary>
      [SerializeField]
      private Vector3 _size = Vector3.one;
      
      /// <summary>
      /// The size of the plane, where x=width, y=length.
      /// </summary>
      public Vector3 Size
      {
         get => _size;
         set => _size = value;
      } 

      /// <summary>
      /// Returns the vertices for a cube.
      /// </summary>
      /// <returns>The vertices for a cube.</returns>
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
      /// Returns triangles for the cube in order: front, top, right, left, back, bottom
      /// </summary>
      /// <returns>The triangles for the cube.</returns>
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
