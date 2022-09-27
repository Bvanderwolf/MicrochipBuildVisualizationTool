using System;
using BWolf.Meshes.Generation;
using BWolf.UserInteraction.Utility;
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

        public int ExtrudeLevel { get; private set; }

        private Vector3 _initialPosition;

        private GameObject _cube;

        private PlaneMeshGenerator _plane;

        private Renderer _renderer;

        private void Awake()
        {
            _plane = GetComponent<PlaneMeshGenerator>();
            _renderer = GetComponent<Renderer>();
        }

        private void Start()
        {
            _initialPosition = transform.position;
        }

        public void IncrementExtrudeLevel()
        {
            if (ExtrudeLevel == 0)
                CreateExtrudeCube();
            else
                Extrude(_extrudeHeight);
            
            ExtrudeLevel++;
        }

        public void DecrementExtrudeLevel()
        {
            if (ExtrudeLevel == 0)
                return;
            
            if (ExtrudeLevel == 1)
                DestroyExtrudeCube();
            else
                Extrude(-_extrudeHeight);

            ExtrudeLevel--;
        }

        /// <summary>
        /// Switches the parents of cube and plane before destroying the cube
        /// And resetting the plane to its initial position.
        /// </summary>
        private void DestroyExtrudeCube()
        {
            transform.SetParent(_cube.transform.parent);
            
            Destroy(_cube);

            transform.position = _initialPosition;
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

            // Switch the plane and the cube's parents and place the plane at the top.
            thisTransform.ReplaceParent(cubeTransform);
            Vector3 planePosition = thisTransform.position;
            planePosition.y += _extrudeHeight + 0.001f;
            thisTransform.position = planePosition;
        }

        /// <summary>
        /// Extrudes the grid plane upwards by adding height to the vertical scale of the cube.
        /// </summary>
        private void Extrude(float height)
        {
            Vector3 cubeLocalScale = _cube.transform.localScale;
            Vector3 cubePosition = _cube.transform.position;
            cubeLocalScale.y += height;
            cubePosition.y += (height * 0.5f);
            _cube.transform.localScale = cubeLocalScale;
            _cube.transform.position = cubePosition;
        }
    }
}