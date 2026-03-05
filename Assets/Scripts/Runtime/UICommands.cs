using UnityEngine;
using UnityEngine.UIElements;

namespace Runtime
{
    public class UICommands : MonoBehaviour
    {
        #region methodes

        #region unity events
        
        private void OnEnable()
        {
            GetComponent<PanelRenderer>().RegisterUIReloadCallback(OnUIReload);
        }

        private void OnDisable()
        {
            GetComponent<PanelRenderer>().UnregisterUIReloadCallback(OnUIReload);

            _startButton?.UnregisterCallback<ClickEvent>(SelectMode);
            _backFromModesButton?.UnregisterCallback<ClickEvent>(SelectMode);
            _settingsButton?.UnregisterCallback<ClickEvent>(Settings);
            _backFromSettingsButton?.UnregisterCallback<ClickEvent>(Settings);
        }

        #endregion
        
        #region setup
        
        private void OnUIReload(PanelRenderer renderer, VisualElement root)
        {
            _root = root;
            
            _modeLabel = root.Q<Label>("Mode");
            
            _settingsButton = root.Q<Button>("Settings");
            _settingsButton.RegisterCallback<ClickEvent>(Settings);
            
            _backFromSettingsButton = root.Q<Button>("BackFromSettings");
            _backFromSettingsButton.RegisterCallback<ClickEvent>(Settings);
            
            _startButton = root.Q<Button>("Start");
            _startButton.RegisterCallback<ClickEvent>(SelectMode);
            
            _backFromModesButton = root.Q<Button>("BackFromModes");
            _backFromModesButton.RegisterCallback<ClickEvent>(SelectMode);
            
            _soloButton = root.Q<Button>("Solo");
            _soloButton.RegisterCallback<ClickEvent>(SetModeSolo);
            
            _onlineButton = root.Q<Button>("Multi");
            _onlineButton.RegisterCallback<ClickEvent>(SetModeOnline);
        }
        
        #endregion

        #region commands

        private void SelectMode(ClickEvent evt)
        {
            _root[0].enabledSelf = !_root[0].enabledSelf;
            _root[2].enabledSelf = !_root[2].enabledSelf;
            
            if (!_root[2].enabledSelf)
                _modeLabel.text = "Mode ?";
        }
        
        private void Settings(ClickEvent evt)
        {
            _root[1].enabledSelf = !_root[1].enabledSelf;
            _root[0].enabledSelf = !_root[0].enabledSelf;
        }

        private void SetModeSolo(ClickEvent evt)
        {
            _modeLabel.text = "Solo !";
        }

        private void SetModeOnline(ClickEvent evt)
        {
            _modeLabel.text = "Online !";
        }
        
        #endregion

        #endregion

        #region fields

        private PanelRenderer _panel;
        
        private VisualElement _root;

        private Button _startButton;
        
        private Button _settingsButton;

        private Button _backFromSettingsButton;
        
        private Button _backFromModesButton;
        
        private Button _soloButton;
        
        private Button _onlineButton;
        
        private Label _modeLabel;

        #endregion
    }
}