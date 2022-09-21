using System;
using BWolf.Meshes.Generation;
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

        public float ExtrudeHeight
        {
            get => _extrudeHeight;
            set => _extrudeHeight = value;
        }

        private int _extrudeLevel;

        private GameObject _cube;

        private PlaneMeshGenerator _plane;

        private Renderer _renderer;

        private void Awake()
        {
            _plane = GetComponent<PlaneMeshGenerator>();
            _renderer = GetComponent<Renderer>();
        }

        public void IncrementExtrudeLevel()
        {
            if (_extrudeLevel == 0)
                CreateExtrudeCube();
            else
                Extrude();

            _extrudeLevel++;
        }

        /// <summary>
        /// Creates the cube to be used for displaying extrusion of the grid plane.
        /// </summary>
        private void CreateExtrudeCube()
        {
            Transform thisTransform = transform;
 
            // Create a primitive cube with the same material as this grid plane.
            _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _cube.GetComponent<Renderer>().material = new Material(_renderer.material)
            {
                color = _plane.InitialColor
            };
            
            // Set the cube to replace the plane at its position.
            Transform cubeTransform = _cube.transform;
            Vector3 cubePosition = thisTransform.position;
            cubePosition.y += _extrudeHeight * 0.5f;
            cubeTransform.position = cubePosition;
            cubeTransform.localScale = new Vector3(_plane.Size.x, _extrudeHeight, _plane.Size.y);

            // Parent the plane to the cube and place it at its top.
            thisTransform.SetParent(_cube.transform);
            Vector3 planePosition = thisTransform.position;
            planePosition.y += _extrudeHeight + 0.001f;
            thisTransform.position = planePosition;
        }

        /// <summary>
        /// Extrudes the grid plane by increasing the vertical scale of the cube.
        /// </summary>
        private void Extrude()
        {
            Vector3 cubeLocalScale = _cube.transform.localScale;
            Vector3 cubePosition = _cube.transform.position;
            cubeLocalScale.y += _extrudeHeight;
            cubePosition.y += (_extrudeHeight * 0.5f);
            _cube.transform.localScale = cubeLocalScale;
            _cube.transform.position = cubePosition;
        }
    }
}