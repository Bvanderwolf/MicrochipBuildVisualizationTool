using System;
using System.Linq;
using BWolf.UserInteraction.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BWolf.UserInteraction
{
    public class OptionsCanvas : MonoBehaviour
    {
        [SerializeField]
        private MeshSelector _selector;
        
        [SerializeField]
        private Vector3 _offset = new Vector3(0, 1, 0);
        
        [SerializeField]
        private Button _buttonPrefab;

        private void Awake()
        {
            _selector.SelectionChanged += OnSelectionChanged;
        }

        private void OnSelectionChanged()
        {
            GameObject[] selection = _selector.Selection;
            if (selection.Length == 0)
                return;
            
            Vector3 averagePosition = selection.Select(selected => selected.transform.position).Average();
            Vector3 displayPosition = averagePosition + _offset;

            transform.position = displayPosition;
        }
    }
}
