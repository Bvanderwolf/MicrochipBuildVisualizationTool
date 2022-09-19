using System;
using BWolf.Meshes.Generation;
using BWolf.UserInteraction;
using UnityEngine;

namespace BWolf.Meshes.Manipulation
{
    public class GridManipulator : MonoBehaviour
    {
        [SerializeField]
        private OptionsCanvas _options;

        [SerializeField]
        private MeshSelector _selector;

        private void Start()
        {
            _options.SetOnClick(OptionsCanvas.DEPOSE, OnDepose);
            _options.SetOnClick(OptionsCanvas.ETCH, OnEtch);
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
