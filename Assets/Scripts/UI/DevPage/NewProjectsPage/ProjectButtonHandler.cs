using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProjectButtonHandler : MonoBehaviour, IButtonInfoHandler
{
    private IButtonInfo _project;
    private Button _button;
    private TextMeshProUGUI _text;

    public IButtonInfo ButtonInfo
    {
        get => _project;
        set
        {
            _project = value;
            SetButtonAttributes();
        }
    }

    private void Awake()
    {
        _button = gameObject.GetComponent<Button>();
        var textObject = gameObject.transform.GetChild(0).gameObject;
        _text = textObject.GetComponent<TextMeshProUGUI>();
    }

    private void SetButtonAttributes()
    {
        _text.text = ButtonInfo.Name;
        var colours = _button.colors;
        colours.normalColor = ButtonInfo.Color;
        colours.selectedColor = ButtonInfo.Color;
        _button.colors = colours;
    }
}
