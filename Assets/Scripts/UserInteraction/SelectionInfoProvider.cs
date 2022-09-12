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

        public bool SelectionIsEtchable()
        {
            // Based on the current selection of planes, can we show the 'Etch' option?
            return false;
        }
    }
}