using System;
using System.Collections.Generic;
using System.Linq;
using BWolf.UserInteraction.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BWolf.UserInteraction
{
    public class OptionsCanvas : MonoBehaviour
    {
        public const string DEPOSE = "Depose";

        public const string ETCH = "Etch";
        
        [SerializeField]
        private MeshSelector _selector;

        [SerializeField]
        private SelectionInfoProvider _selectionInfo;

        [SerializeField]
        private Transform _buttonParent;
        
        [SerializeField]
        private Vector3 _offset = new Vector3(0, 1, 0);
        
        [SerializeField]
        private Button _buttonPrefab;

        private readonly Dictionary<string, OptionButton> _options = new Dictionary<string, OptionButton>();

        private struct OptionButton
        {
            public Button button;

            public Func<bool> condition;
        }

        private void Awake()
        {
            _selector.SelectionChanged += OnSelectionChanged;
            
            AddOption(DEPOSE, _selectionInfo.SelectionIsDepositable);
            AddOption(ETCH, _selectionInfo.SelectionIsEtchable);
        }

        private void Start()
        {
            SetActive(false);
        }

        public void AddOption(string optionName, Func<bool> condition = null)
        {
            Button button = Instantiate(_buttonPrefab, _buttonParent);
            TMP_Text textRenderer = button.GetComponentInChildren<TMP_Text>();
            textRenderer.text = optionName;
            
            _options.Add(optionName, new OptionButton{ button = button, condition = condition });
        }

        public void SetOnClick(string optionName, UnityAction action)
        {
            Button button = _options[optionName].button;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(action);
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

            // Determine whether we want the canvas to be active based
            // on whether any object has been selected.
            SetActive(selectedAnyObject);
        }

        private void SetActive(bool value)
        {
            gameObject.SetActive(value);
            
            if (value)
            {
                foreach (OptionButton option in _options.Values)
                {
                    bool canBeInteractable = option.condition == null || option.condition.Invoke();
                    option.button.interactable = canBeInteractable;
                }
            }
        }
    }
}
