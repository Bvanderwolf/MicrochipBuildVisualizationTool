using UnityEngine;

namespace BWolf.Meshes.Manipulation
{
    public class GridPlaneManipulator : MonoBehaviour
    {
        /// <summary>
        /// The amount of height gained from an extrude level
        /// increase in world units. 
        /// </summary>
        [SerializeField]
        private float _extrudeHeight = 1f;
        
        public void IncrementExtrudeLevel()
        {
            // First extrude means generating a cube underneath the plane and placing the plane on top
            // afterwards the cube size is manipulated.
            Debug.Log($"Extruding {name} by one level");
        }
    }
}