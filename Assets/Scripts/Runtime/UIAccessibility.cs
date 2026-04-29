using UnityEngine;
using UnityEngine.Audio;
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
            
            OnUnregisterButtons();
        }
        
        #endregion
        
        #region setup

        private void OnReloadUI(PanelRenderer panel, VisualElement root)
        {
            _root = root;
            _panel = panel;
            
            OnRegisterPanels();
            OnRegisterButtons();
        }

        private void OnRegisterPanels()
        {
            _mainPanel = _root.Q<VisualElement>("MainPanel");
            _settingsSubPanel = _root.Q<VisualElement>("SettingsSubPanel");
            _graphicsPanel = _root.Q<VisualElement>("GraphicsPanel");
            _soundPanel = _root.Q<VisualElement>("SoundPanel");
            _textsPanel = _root.Q<VisualElement>("TextsPanel");
        }

        private void OnRegisterButtons()
        {
            _startGameButton = _root.Q<Button>("Start");
            _startGameButton.RegisterCallback<ClickEvent>(StartGame);
            
            _settingsButton = _root.Q<Button>("Settings");
            _settingsButton.RegisterCallback<ClickEvent>(Settings);
            
            _backFromSubButton = _root.Q<Button>("BackFromSubSet");
            _backFromSubButton.RegisterCallback<ClickEvent>(Settings);
            
            _quitGameButton = _root.Q<Button>("Quit");
            _quitGameButton.RegisterCallback<ClickEvent>(QuitGame);
            
            _soundsButton = _root.Q<Button>("Sounds");
            _soundsButton.RegisterCallback<ClickEvent>(Sounds);
            
            _backFromSoundsButton = _root.Q<Button>("BackFromSounds");
            _backFromSoundsButton.RegisterCallback<ClickEvent>(Sounds);
            
            _textsButton = _root.Q<Button>("Texts");
            _textsButton.RegisterCallback<ClickEvent>(Texts);
            
            _backFromTextsButton = _root.Q<Button>("BackFromTexts");
            _backFromTextsButton.RegisterCallback<ClickEvent>(Texts);
            
            _graphicsButton = _root.Q<Button>("Graphics");
            _graphicsButton.RegisterCallback<ClickEvent>(Graphics);
            
            _backFromGraphicsButton = _root.Q<Button>("BackFromGraphics");
            _backFromGraphicsButton.RegisterCallback<ClickEvent>(Graphics);
        }

        private void OnUnregisterButtons()
        {
            _startGameButton.UnregisterCallback<ClickEvent>(StartGame);
            _settingsButton.UnregisterCallback<ClickEvent>(Settings);
            _backFromSubButton.UnregisterCallback<ClickEvent>(Settings);
            _quitGameButton.UnregisterCallback<ClickEvent>(QuitGame);
            _soundsButton.UnregisterCallback<ClickEvent>(Sounds);
            _backFromSoundsButton.UnregisterCallback<ClickEvent>(Sounds);
            _textsButton.UnregisterCallback<ClickEvent>(Texts);
            _backFromTextsButton.UnregisterCallback<ClickEvent>(Texts);
            _graphicsButton.UnregisterCallback<ClickEvent>(Graphics);
            _backFromGraphicsButton.UnregisterCallback<ClickEvent>(Graphics);
        }

        #endregion
        
        #region commands

        #region navigation
        
        private void StartGame(ClickEvent evt)
        {
            Debug.Log("Starting game");
        }

        private void QuitGame(ClickEvent evt)
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        
        private void Settings(ClickEvent evt)
        {
            _mainPanel.enabledSelf = !_mainPanel.enabledSelf;
            _settingsSubPanel.enabledSelf = !_settingsSubPanel.enabledSelf;
        }

        private void Sounds(ClickEvent evt)
        {
            _soundPanel.enabledSelf = !_soundPanel.enabledSelf;
            _settingsSubPanel.enabledSelf = !_settingsSubPanel.enabledSelf;
        }

        private void Texts(ClickEvent evt)
        {
            _textsPanel.enabledSelf = !_textsPanel.enabledSelf;
            _settingsSubPanel.enabledSelf = !_settingsSubPanel.enabledSelf;
        }

        private void Graphics(ClickEvent evt)
        {
            _graphicsPanel.enabledSelf = !_graphicsPanel.enabledSelf;
            _settingsSubPanel.enabledSelf = !_settingsSubPanel.enabledSelf;
        }
        
        #endregion
        
        #region sounds
        
        private void SetMasterVolume(ChangeEvent<float> evt)
        {
            audioMixer.SetFloat("master", evt.newValue);
        }
        
        private void SetMusicVolume(ChangeEvent<float> evt)
        {
            audioMixer.SetFloat("music", evt.newValue);
        }

        private static void SetFullscreen(bool value)
        {
            Screen.fullScreen = value;
        }
        
        #endregion
        
        #region graphics

        private static void ToggleFullscreen(bool value)
        {
            Screen.fullScreen = value;
        }
        
        #endregion
        
        #region texts

        private void SetFontSize(ChangeEvent<float> evt)
        {
            
        }
        
        #endregion

        #endregion

        #endregion

        #region fields

        [SerializeField] private AudioMixer audioMixer;
        
        private PanelRenderer _panel;
        
        private VisualElement _root;

        #region panels
        
        private VisualElement _mainPanel;
        
        private VisualElement _settingsSubPanel;

        private VisualElement _soundPanel;

        private VisualElement _graphicsPanel;
        
        private VisualElement _textsPanel;

        #endregion
        
        #region navigation
        
        private Button _startGameButton;
        
        private Button _quitGameButton;
        
        private Button _settingsButton;

        private Button _backFromSubButton;
        
        private Button _soundsButton;
        
        private Button _backFromSoundsButton;
        
        private Button _graphicsButton;
        
        private Button _backFromGraphicsButton;
        
        private Button _textsButton;
        
        private Button _backFromTextsButton;
        
        #endregion
        
        #region sounds
        
        
        
        #endregion
        
        #region graphics
        
        
        
        #endregion
        
        #region texts
        
        
        
        #endregion

        #endregion
    }
}