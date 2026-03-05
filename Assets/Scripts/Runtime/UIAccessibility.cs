using UnityEngine;
using UnityEngine.UIElements;

namespace Runtime
{
    public class UIAccessibility : MonoBehaviour
    {
        #region methodes

        #region unity events
        
        private void OnEnable()
        {
            GetComponent<PanelRenderer>().RegisterUIReloadCallback(OnReloadUI);
        }

        private void OnDisable()
        {
            GetComponent<PanelRenderer>().UnregisterUIReloadCallback(OnReloadUI);
        }
        
        #endregion
        
        #region setup

        private void OnReloadUI(PanelRenderer panel, VisualElement root)
        {
            _root = root;
            _panel = panel;
        }

        #endregion

        #endregion

        #region fields

        private PanelRenderer _panel;
        
        private VisualElement _root;

        #endregion
    }
}