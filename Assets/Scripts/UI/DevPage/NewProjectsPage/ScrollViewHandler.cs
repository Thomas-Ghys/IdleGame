using System.Collections.Generic;
using Domain.Projects;
using Domain.Projects.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.DevPage.NewProjectsPage
{
    public class ScrollViewHandler : MonoBehaviour
    {
        public DevPageHandler DevPageHandler;

        private GameObject _content;
        private readonly List<GameObject> _buttons = new();

        private void Awake()
        {
            if (gameObject.GetComponent<ScrollRect>() == null)
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

        public List<GameObject> Buttons
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
            newProjectButton.GetComponentInChildren<IButtonInfoHandler>().Initialize(buttonInfo, DevPageHandler);
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