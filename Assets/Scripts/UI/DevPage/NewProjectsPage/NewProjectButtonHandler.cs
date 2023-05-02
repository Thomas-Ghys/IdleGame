using System;
using Domain.Projects;
using Domain.Projects.Interfaces;
using TMPro;
using Unity.VisualScripting;
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
        }

        public void Initialize(Project buttonInfo)
        {
            gameObject.name += $" {buttonInfo.Name}";
            ButtonInfo = buttonInfo;

            startButton.GetComponent<Button>().onClick.AddListener(() => { OnStartProject.Invoke(buttonInfo.CloneWithNewId()); });
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