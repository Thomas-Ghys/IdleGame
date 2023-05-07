using System;
using Domain.Projects;
using Domain.Projects.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.DevPage.NewProjectsPage
{
    public class NewProjectButtonHandler : MonoBehaviour, IButtonInfoHandler
    {
        private Project _buttonInfo;
        private Button _button;
        private TextMeshProUGUI _text;

        [SerializeField] private Button startButton;
        public static Action<Project> OnStartProject;

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
        }

        public void Initialize(IButtonInfo buttonInfo)
        {
            ButtonInfo = buttonInfo;
            gameObject.name += $" {_buttonInfo.Name}";

            startButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                OnStartProject.Invoke(_buttonInfo.CloneWithNewId());
            });
        }

        private void SetButtonAttributes()
        {
            _text.text = _buttonInfo.Name;
            var colours = _button.colors;
            colours.normalColor = _buttonInfo.Color;
            colours.selectedColor = _buttonInfo.Color;
            _button.colors = colours;
        }
    }
}