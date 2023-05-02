using Domain.Projects;
using Domain.Projects.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.DevPage.RunningProjectsPage
{
    public class RunningProjectButtonHandler : MonoBehaviour, IButtonInfoHandler
    {
        private Project _buttonInfo;
        private Button _button;
        private TextMeshProUGUI _text;
        private TextMeshProUGUI _timeText;
        
        public Project ButtonInfo
        {
            get => _buttonInfo;
            private set
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
            var timeTextObject = gameObject.transform.Find("Time").gameObject;
            _timeText = timeTextObject.GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            ProjectLogic.OnProjectTimeStringChange += UpdateButtonTime;
        }

        private void OnDisable()
        {
            ProjectLogic.OnProjectTimeStringChange -= UpdateButtonTime;
        }

        public void Initialize(Project buttonInfo)
        {
            gameObject.name += $" {buttonInfo.Name}";
            ButtonInfo = buttonInfo;
        }

        private void SetButtonAttributes()
        {
            _text.text = ButtonInfo.Name;
            var colours = _button.colors;
            colours.normalColor = ButtonInfo.Color;
            colours.selectedColor = ButtonInfo.Color;
            _button.colors = colours;
        }

        private void UpdateButtonTime()
        {
            _timeText.text = ButtonInfo.TimeActiveAsString;
        }
    }
}