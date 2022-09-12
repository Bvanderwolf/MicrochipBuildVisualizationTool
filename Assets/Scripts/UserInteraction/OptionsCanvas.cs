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

        private void Start()
        {
            SetActive(false);
        }

        private void OnSelectionChanged()
        {
            GameObject[] selection = _selector.Selection;
            bool selectedAnyObject = selection.Length != 0;
            if (selectedAnyObject)
            {
                Vector3 averagePosition = selection.Select(selected => selected.transform.position).Average();
                Vector3 displayPosition = averagePosition + _offset;

                transform.position = displayPosition;
            }
            Debug.Log(selection.Length);
            // Determine whether we want the canvas to be active based
            // on whether any object has been selected.
            SetActive(selectedAnyObject);
        }

        private void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}
