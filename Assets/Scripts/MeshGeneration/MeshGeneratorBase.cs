using UnityEngine;

namespace BWolf.MeshGeneration
{
    public abstract class MeshGeneratorBase : MonoBehaviour
    {
        public abstract void GenerateMesh(Material material = null);
    }
}
