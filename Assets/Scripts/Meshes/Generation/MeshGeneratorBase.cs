using UnityEngine;

namespace BWolf.Meshes.Generation
{
    public abstract class MeshGeneratorBase : MonoBehaviour
    {
        public abstract void GenerateMesh(Material material = null);
    }
}
