using BWolf.Meshes.Manipulation;
using UnityEngine;

namespace BWolf.UserInteraction
{
    public class SelectionInfoProvider : MonoBehaviour
    {
        [SerializeField]
        private MeshSelector _selector;

        public bool SelectionIsDepositable()
        {
            // Based on the current selection of planes, can we show the 'Depose' option?
            return true;
        }

        /// <summary>
        /// Returns whether, based on the current selection of planes, we can show the 'Etch' option.
        /// </summary>
        /// <returns></returns>
        public bool SelectionIsEtchable()
        {
            GameObject[] selection = _selector.Selection;
            if (selection.Length == 0)
                return false;

            // If the selection is just one plane, return whether it has an extrude level of at least 1.
            if (selection.Length == 1 && selection[0].TryGetComponent(out GridPlaneManipulator singlePlane))
                return singlePlane.ExtrudeLevel >= 1;
            
            // If the selection is more than one plane, there needs to be at least 1 that has an extrude level
            // of 1 or higher.
            for (int i = 0; i < selection.Length; i++)
                if (selection[i].TryGetComponent(out GridPlaneManipulator plane) && plane.ExtrudeLevel >= 1)
                    return true;
            
            return false;
        }
    }
}