using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWolf.UserInteraction.Utility
{
    public class LookingAtTransform : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;

        [SerializeField]
        private bool _mirror = false;
        
        private void Update()
        {
            if (_target == null)
                return;
            
            transform.LookAt(_target);
            if (_mirror)
                transform.Rotate(0, 180, 0);
        }
    }
}
