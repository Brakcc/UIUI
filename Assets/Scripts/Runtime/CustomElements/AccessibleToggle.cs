using System;
using UnityEngine.UIElements;

namespace Runtime.CustomElements;

[UxmlElement]
public partial class AccessibleToggle : VisualElement
{
    #region properties

    [UxmlAttribute]
    public string Text
    {
        get => _label.text;
        set => _label.text = value;
    }

    [UxmlAttribute]
    public bool Value
    {
        get => _value;
        set => Set(value);
    }
    
    public Action<bool> Toggled { get; set; }

    #endregion

    #region constructors

    public AccessibleToggle()
    {
        RegisterCallback<AttachToPanelEvent>(_ => { });
        RegisterCallback<DetachFromPanelEvent>(_ => { });

        _label = new Label("OnOff")
        {
            name = "Text"
        };

        _border = new VisualElement
        {
            name = "Border"
        };
        _border.AddToClassList("aswitch-border");

        _control = new VisualElement
        {
            name = "Control"
        };
        _control.AddToClassList("aswitch-control");
        
        Add(_label);
        Add(_border);
        _border.Add(_control);
        
        RegisterCallback<MouseDownEvent>(_ => { Value = !Value; });
    }

    #endregion
    
    #region methodes

    private void Set(bool value)
    {
        _value = value;
        Toggled?.Invoke(value);
        SetState(value);
    }

    private void SetState(bool value)
    {
        _border.EnableInClassList("aswitch-border_on", value);
        _control.EnableInClassList("aswitch-control_on", value);
    }

    #endregion

    #region fields

    private Label _label;

    private VisualElement _border;

    private VisualElement _control;

    private bool _value;

    #endregion
}