using Domain.Projects.Interfaces;
using UI.DevPage.NewProjectsPage;
using UnityEngine;

namespace UI.Global
{
    public class PanelController : MonoBehaviour
    {
        public GameObject Panel;
        private IButtonInfoHandler _projectButtonHandler;
        private bool _panelIsOpen = false;

        private void Start()
        {
            _projectButtonHandler = gameObject.GetComponent<IButtonInfoHandler>();
            if (_projectButtonHandler == null)
            {
                Debug.LogError($"The object containing a {nameof(PanelController)} component must have an {nameof(IButtonInfoHandler)} component.");
            }
        }

        public void OpenPanel()
        {
            if (Panel == null)
            {
                return;
            }

            if (_panelIsOpen)
            {
                Collapse();
            }
            else
            {
                _projectButtonHandler.CollapseAll();
                Expand();
            }
        }

        private void Expand()
        {
            var panelRectTransform = Panel.GetComponent<RectTransform>();
            var maskRectTransform = gameObject.transform.parent.GetComponent<RectTransform>();
            var startingSize = maskRectTransform.sizeDelta;

            var newSize = new Vector2(startingSize.x, startingSize.y + panelRectTransform.rect.height);

            SetPanelHeight(maskRectTransform, newSize);
                
            _panelIsOpen = true;
        }

        public void Collapse()
        {
            if (!_panelIsOpen)
            {
                return;
            }
            var panelRectTransform = Panel.GetComponent<RectTransform>();
            var maskRectTransform = gameObject.transform.parent.GetComponent<RectTransform>();
            var startingSize = maskRectTransform.sizeDelta;

            var newSize = new Vector2(startingSize.x, startingSize.y - panelRectTransform.rect.height);

            SetPanelHeight(maskRectTransform, newSize);
                
            _panelIsOpen = false;
        }

        private void SetPanelHeight(RectTransform rect,Vector2 newSize)
        {
            // Sets the new size of the rectangle.
            rect.sizeDelta = newSize;
                
            // Moves the position back to the correct location.
            rect.anchoredPosition =
                new Vector2(rect.anchoredPosition.x, rect.rect.height / -2);
        }
    }
}