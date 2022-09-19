using UnityEditor;
using UnityEngine;

namespace BWolf.Meshes.Generation
{
    /// <summary>
    /// A custom editor class that adds a generation button to the default inspector.
    /// </summary>
    [CustomEditor(typeof(MeshGeneratorBase), true)]
    public class MeshGeneratorEditor : Editor
    {
        /// <summary>
        /// The mesh generator object for which the inspector is being drawn.
        /// </summary>
        private MeshGeneratorBase _object;
        
        /// <summary>
        /// Sets the object reference using the target property.
        /// Using as cast since target is null sometimes.
        /// </summary>
        private void OnEnable() => _object = target as MeshGeneratorBase;

        /// <summary>
        /// Draws the inspector, drawing the default inspector and a
        /// 'generate' button that, when clicked, generates the mesh.
        /// </summary>
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            if (_object != null && GUILayout.Button("Generate"))
                _object.GenerateMesh();
        }
    }
}
