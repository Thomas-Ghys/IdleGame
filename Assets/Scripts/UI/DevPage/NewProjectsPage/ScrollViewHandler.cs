using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewHandler : MonoBehaviour
{
    private GameObject _content;
    private readonly List<GameObject> _buttons = new();

    private void Start()
    {
        if (gameObject.GetComponent<ScrollRect>() == null)
        {
            Debug.LogError($"This script ({nameof(ScrollViewHandler)}) is only allowed to be placed on scroll views");
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
        newButton.transform.SetSiblingIndex(0);
    }

    public void AddButtonToBottom(Project project, GameObject buttonPrefab)
    {
        var newButton = AddButton(project, buttonPrefab);
        newButton.transform.SetSiblingIndex(_content.transform.childCount - 1);
    }

    private GameObject AddButton(IButtonInfo buttonInfo, GameObject buttonPrefab)
    {
        var newProjectButton = Instantiate(buttonPrefab, _content.transform, false);
        newProjectButton.GetComponent<IButtonInfoHandler>().ButtonInfo = buttonInfo;
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