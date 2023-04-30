using UnityEngine;

namespace UI.Global
{
    public class PanelOpener : MonoBehaviour
    {
        public GameObject Panel;
        private bool _panelIsOpen = false;

        public void OpenPanel()
        {
            if (Panel == null)
            {
                return;
            }

            if (!_panelIsOpen)
            {
                var panelRectTransform = Panel.GetComponent<RectTransform>();
                var maskRectTransform = gameObject.transform.parent.GetComponent<RectTransform>();
                var startingSize = maskRectTransform.sizeDelta;

                var newSize = new Vector2(startingSize.x, startingSize.y + panelRectTransform.rect.height /*200*/);

                // Sets the new size of the rectangle.
                maskRectTransform.sizeDelta = newSize;
                
                // Moves the position back to the correct location.
                maskRectTransform.anchoredPosition =
                    new Vector2(maskRectTransform.anchoredPosition.x, maskRectTransform.rect.height / -2);
                _panelIsOpen = true;
            }
        }
    }
}