using Domain.Projects.Interfaces;
using TMPro;
using UI.Global;
using UnityEngine;
using UnityEngine.UI;

namespace UI.DevPage.NewProjectsPage
{
    public class ProjectButtonHandler : MonoBehaviour, IButtonInfoHandler
    {
        private IButtonInfo _buttonInfo;
        private Button _button;
        private TextMeshProUGUI _text;

        public IPageHandler PageHandler { get; private set; }
        
        public IButtonInfo ButtonInfo
        {
            get => _buttonInfo;
            set
            {
                _buttonInfo = value;
                SetButtonAttributes();
            }
        }

        private void Awake()
        {
            _button = gameObject.GetComponent<Button>();
            var textObject = gameObject.transform.GetChild(0).gameObject;
            _text = textObject.GetComponent<TextMeshProUGUI>();
        }

        // TODO: Sambar: Move this to it's own script so it can be separate from the proper logic
        public void Expand()
        {
            
        }

        // TODO: Sambar: Move this to it's own script so it can be separate from the proper logic
        public void Collapse()
        {
            
        }
        
        public void StartProject()
        {
            PageHandler.InvokeButton(_buttonInfo);
        }

        public void Initialize(IButtonInfo buttonInfo, DevPageHandler devPageHandler)
        {
            ButtonInfo = buttonInfo;
            PageHandler = devPageHandler;
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
}
