using System;
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

        public static event Action<Project> OnMoveToProjectDetails;

        public IButtonInfo ButtonInfo
        {
            get => _buttonInfo;
            private set
            {
                _buttonInfo = value as Project;
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

        public void Initialize(IButtonInfo buttonInfo)
        {
            var projectButtonInfo = buttonInfo as Project;
            gameObject.name += $" {projectButtonInfo.Name}";
            ButtonInfo = projectButtonInfo;
        }

        public void MoveToProjectDetails()
        {
            OnMoveToProjectDetails?.Invoke(_buttonInfo);
        }

        private void SetButtonAttributes()
        {
            _text.text = _buttonInfo.Name;
            var colours = _button.colors;
            colours.normalColor = _buttonInfo.Color;
            colours.selectedColor = _buttonInfo.Color;
            _button.colors = colours;
        }

        private void UpdateButtonTime()
        {
            _timeText.text = _buttonInfo.TimeActiveAsString;
        }
    }
}