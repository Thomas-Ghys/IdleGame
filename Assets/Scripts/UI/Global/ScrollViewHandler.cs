using System.Collections.Generic;
using Domain.Projects;
using Domain.Projects.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Global
{
    public class ScrollViewHandler : MonoBehaviour
    {
        private GameObject _content;
        private ScrollRect _scrollRect;
        private readonly List<GameObject> _buttons = new();

        private void Awake()
        {
            _scrollRect = gameObject.GetComponent<ScrollRect>();
            if (_scrollRect == null)
            {
                Debug.LogError(
                    $"This script ({nameof(ScrollViewHandler)}) is only allowed to be placed on scroll views");
            }

            _content = gameObject.transform.Find("Viewport")?.Find("Content")?.gameObject;
            if (_content == null)
            {
                Debug.LogError("The Content of the scroll view could not be found. " +
                               "This could be because the names of the \"Viewport\" or \"Content\" game objects have been changed.");
            }
        }

        private void Start()
        {
            _scrollRect.scrollSensitivity = Globals.General.DefaultScrollingSensitivity;
        }

        private List<GameObject> Buttons
        {
            get
            {
                if (_buttons.Count != _content.transform.childCount)
                {
                    RefreshButtonsCollection();
                }

                return _buttons;
            }
        }

        public void AddButtonToTop(Project project, GameObject buttonPrefab)
        {
            var newButton = AddButton(project, buttonPrefab);
            newButton.transform.SetAsFirstSibling();
        }

        public void AddButtonToBottom(Project project, GameObject buttonPrefab)
        {
            var newButton = AddButton(project, buttonPrefab);
            newButton.transform.SetAsLastSibling();
        }

        private GameObject AddButton(Project buttonInfo, GameObject buttonPrefab)
        {
            var newProjectButton = Instantiate(buttonPrefab, _content.transform, false);
            var buttonHandler = newProjectButton.GetComponent<IButtonInfoHandler>();
            buttonHandler ??= newProjectButton.GetComponentInChildren<IButtonInfoHandler>();
            buttonHandler.Initialize(buttonInfo);
            return newProjectButton;
        }

        private void RefreshButtonsCollection()
        {
            Buttons.Clear();
            for (var i = 0; i < _content.transform.childCount; i++)
            {
                Buttons.Add(_content.transform.GetChild(i).gameObject);
            }
        }
    }
}