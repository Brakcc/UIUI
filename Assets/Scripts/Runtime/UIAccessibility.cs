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
            
            _settingsButton.UnregisterCallback<ClickEvent>(Settings);
            _backButton.UnregisterCallback<ClickEvent>(Settings);
        }
        
        #endregion
        
        #region setup

        private void OnReloadUI(PanelRenderer panel, VisualElement root)
        {
            _root = root;
            _panel = panel;
            
            _settingsButton = root.Q<Button>("Settings");
            _settingsButton.RegisterCallback<ClickEvent>(Settings);
            
            _backButton = root.Q<Button>("BackFromSettings");
            _backButton.RegisterCallback<ClickEvent>(Settings);
        }

        #endregion
        
        #region commands

        private void Settings(ClickEvent evt)
        {
            _root[1].enabledSelf = !_root[1].enabledSelf;
        }

        #endregion

        #endregion

        #region fields

        private PanelRenderer _panel;
        
        private VisualElement _root;

        private Button _settingsButton;

        private Button _backButton;

        #endregion
    }
}