using System;
using BWolf.Meshes.Generation;
using BWolf.UserInteraction;
using UnityEngine;

namespace BWolf.Meshes.Manipulation
{
    public class GridManipulator : MonoBehaviour
    {
        /// <summary>
        /// The amount of height gained from an extrude level
        /// increase for grid planes in world units. 
        /// </summary>
        [SerializeField]
        private float _extrudeHeight = 1f;
        
        [SerializeField]
        private OptionsCanvas _options;

        [SerializeField]
        private MeshSelector _selector;

        private GridGenerator _generator;

        private void Awake()
        {
            _generator = GetComponent<GridGenerator>();
            _generator.OnGenerate += OnGridGenerated;
        }

        private void Start()
        {
            _options.SetOnClick(OptionsCanvas.DEPOSE, OnDepose);
            _options.SetOnClick(OptionsCanvas.ETCH, OnEtch);
            
            OnGridGenerated();
        }

        private void OnGridGenerated()
        {
            GridPlaneManipulator[] planes = GetComponentsInChildren<GridPlaneManipulator>();
            for (int i = 0; i < planes.Length; i++)
                planes[i].ExtrudeHeight = _extrudeHeight;
        }

        private void OnEtch()
        {
            // TODO: decrement extrude level by one.
            GameObject[] selection = _selector.Selection;
        }

        private void OnDepose()
        {
            // The extrude level of selected game objects with grid
            // plane manipulator behaviour are incremented by one.
            GameObject[] selection = _selector.Selection;
            for (int i = 0; i < selection.Length; i++)
                selection[i].GetComponent<GridPlaneManipulator>()?.IncrementExtrudeLevel();
        }
    }
}
