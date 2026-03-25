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
            _root[0].enabledSelf = !_root[0].enabledSelf;
        }

        private void StartGame()
        {
            Debug.Log("Starting game");
        }

        private void QuitGame()
        {
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

        #endregion

        #endregion

        #region fields

        [SerializeField] private AudioMixer audioMixer;
        
        private PanelRenderer _panel;
        
        private VisualElement _root;

        private Button _settingsButton;

        private Button _backButton;

        #endregion
    }
}