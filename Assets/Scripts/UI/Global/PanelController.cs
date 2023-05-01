using System;
using Domain.Projects.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Global
{
    public class PanelController : MonoBehaviour
    {
        // public delegate void OnFocusDelegate();
        public static Action OnFocus;

        [SerializeField] private GameObject panel;
        [SerializeField] private GameObject buttonRoot;
        private IButtonInfoHandler _projectButtonHandler;
        private bool _panelIsOpen;

        private void Start()
        {
            _projectButtonHandler = gameObject.GetComponent<IButtonInfoHandler>();
            if (_projectButtonHandler == null)
            {
                Debug.LogError($"The object containing a {nameof(PanelController)} component must have an {nameof(IButtonInfoHandler)} component.");
            }
        }

        private void OnEnable()
        {
            OnFocus += Collapse;
        }

        private void OnDisable()
        {
            OnFocus -= Collapse;
        }

        public void OpenPanel()
        {
            if (panel == null)
            {
                return;
            }

            if (_panelIsOpen)
            {
                Collapse();
            }
            else
            {
                Expand();
            }
        }

        private void Expand()
        {
            var panelRectTransform = panel.GetComponent<RectTransform>();
            var testParentThingRect = buttonRoot.GetComponent<RectTransform>();
            var maskRectTransform = gameObject.transform.parent.GetComponent<RectTransform>();
            var startingSize = maskRectTransform.sizeDelta;

            var newSize = new Vector2(startingSize.x, startingSize.y + (panelRectTransform.rect.height - gameObject.GetComponent<RectTransform>().rect.height));

            SetButtonPanelHeight(maskRectTransform, testParentThingRect, newSize);
            LayoutRebuilder.ForceRebuildLayoutImmediate(buttonRoot.transform.parent.GetComponent<RectTransform>());

            OnFocus.Invoke();   // Collapse of itself should not execute because it isn't set as open yet.
            _panelIsOpen = true;
        }

        private void Collapse()
        {
            if (!_panelIsOpen)
            {
                return;
            }
            var panelRectTransform = panel.GetComponent<RectTransform>();
            var buttonRootRect = buttonRoot.GetComponent<RectTransform>();
            var maskRectTransform = gameObject.transform.parent.GetComponent<RectTransform>();
            var startingSize = maskRectTransform.sizeDelta;

            var newSize = new Vector2(startingSize.x, startingSize.y - (panelRectTransform.rect.height - gameObject.GetComponent<RectTransform>().rect.height));
            
            SetButtonPanelHeight(maskRectTransform, buttonRootRect, newSize);
            LayoutRebuilder.ForceRebuildLayoutImmediate(buttonRoot.transform.parent.GetComponent<RectTransform>());
            
            _panelIsOpen = false;
        }

        private void SetButtonPanelHeight(RectTransform maskRect, RectTransform buttonRootTransformRect,Vector2 newSize)
        {
            // Sets the new size of the rectangle.
            maskRect.sizeDelta = newSize;
            buttonRootTransformRect.sizeDelta = newSize;
                
            // Moves the position back to the correct location.
            maskRect.anchoredPosition =
                new Vector2(maskRect.anchoredPosition.x, maskRect.rect.height / -2);
            buttonRootTransformRect.anchoredPosition =
                new Vector2(buttonRootTransformRect.anchoredPosition.x, buttonRootTransformRect.rect.height / -2);
        }
    }
}