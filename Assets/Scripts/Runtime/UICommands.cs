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

            _aButton?.UnregisterCallback<ClickEvent>(A);
        }

        #endregion
        
        #region setup
        
        private void OnUIReload(PanelRenderer renderer, VisualElement root)
        {
            _root = root;
            
            _aButton = root.Q<Button>("A");
            _aButton.RegisterCallback<ClickEvent>(A);
        }
        
        #endregion

        #region commands
        
        private void A(ClickEvent evt)
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAA");

            _root[0][1][0][1].visible = !_root[0][1][0][1].visible;
        }
        
        #endregion

        #endregion

        #region fields

        private PanelRenderer _panel;
        
        private VisualElement _root;
        
        private Button _aButton;

        #endregion
    }
}