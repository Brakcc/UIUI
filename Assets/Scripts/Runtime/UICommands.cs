using Runtime.CustomElements;
using UnityEngine;
using UnityEngine.Audio;
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
            _soloButton?.UnregisterCallback<ClickEvent>(SetModeSolo);
            _onlineButton?.UnregisterCallback<ClickEvent>(SetModeOnline);
            _startGameButton?.UnregisterCallback<ClickEvent>(StartGame);
            _quitGameButton?.UnregisterCallback<ClickEvent>(QuitGame);
            _masterSlider?.UnregisterCallback<ChangeEvent<float>>(SetMasterVolume);
            _musicSlider?.UnregisterCallback<ChangeEvent<float>>(SetMusicVolume);
            _fullScreen.Toggled -= SetFullscreen;
        }

        #endregion
        
        #region setup
        
        private void OnUIReload(PanelRenderer panel, VisualElement root)
        {
            _root = root;
            _panel = panel;
            
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
            
            _startGameButton = root.Q<Button>("StartGame");
            _startGameButton.RegisterCallback<ClickEvent>(StartGame);
            
            _quitGameButton = root.Q<Button>("Quit");
            _quitGameButton.RegisterCallback<ClickEvent>(QuitGame);
            
            _masterSlider = root.Q<Slider>("Master");
            _masterSlider.RegisterCallback<ChangeEvent<float>>(SetMasterVolume);
            
            _musicSlider = root.Q<Slider>("Music");
            _musicSlider.RegisterCallback<ChangeEvent<float>>(SetMusicVolume);

            _fullScreen = root.Q<CustomSlider>("Fullscreen");
            _fullScreen.Toggled += SetFullscreen;
        }
        
        #endregion

        #region commands

        private void SelectMode(ClickEvent evt)
        {
            _root[0].enabledSelf = !_root[0].enabledSelf;
            _root[2].enabledSelf = !_root[2].enabledSelf;

            if (_root[2].enabledSelf)
                return;
            
            _modeLabel.text = "Mode ?";
            _modeLabel.style.fontSize = 145;
            _modeLabel.style.color = Color.white;
            _currentMode = 0;
        }
        
        private void Settings(ClickEvent evt)
        {
            _root[1].enabledSelf = !_root[1].enabledSelf;
            _root[0].enabledSelf = !_root[0].enabledSelf;
        }

        private void SetModeSolo(ClickEvent evt)
        {
            _modeLabel.text = "Solo !";
            _modeLabel.style.color = Color.white;
            _modeLabel.style.fontSize = 145;
            _currentMode = 1;
        }

        private void SetModeOnline(ClickEvent evt)
        {
            _modeLabel.text = "Online !";
            _modeLabel.style.color = Color.white;
            _modeLabel.style.fontSize = 145;
            _currentMode = 2;
        }

        private void StartGame(ClickEvent evt)
        {
            if (!CheckIfMode())
            {
                _modeLabel.text = "No mode selected !";
                _modeLabel.style.color = Color.red;
                _modeLabel.style.fontSize = 70;
                return;
            }

            var t = _currentMode == 1 ? "Solo" : "Online";
            Debug.Log($"Start Game ! : Mode : {t}");
        }

        private void QuitGame(ClickEvent evt)
        {
            Debug.Log("Quit Game !");
            Application.Quit();
            
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

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

        private bool CheckIfMode() => _currentMode != 0;
        
        #endregion

        #endregion

        #region fields

        [SerializeField] private AudioMixer audioMixer;
        
        private PanelRenderer _panel;
        
        private VisualElement _root;

        private Button _startButton;
        
        private Button _settingsButton;

        private Button _backFromSettingsButton;
        
        private Button _backFromModesButton;
        
        private Button _soloButton;
        
        private Button _onlineButton;
        
        private Button _startGameButton;

        private Button _quitGameButton;
        
        private Label _modeLabel;
        
        private Slider _masterSlider;
        
        private Slider _musicSlider;

        private Slider _sfxSlider;
        
        private CustomSlider _fullScreen;
        
        private int _currentMode;

        #endregion
    }
}