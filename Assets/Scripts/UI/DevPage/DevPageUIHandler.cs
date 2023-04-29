using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DevPageUIHandler : MonoBehaviour
{
    private List<GameObject> _pages;
    
    private void Start()
    {
        _pages = new List<GameObject>();
        
        for (var i = 0; i < gameObject.transform.childCount; i++)
        {
            _pages.Add(gameObject.transform.GetChild(i).gameObject);
        }

        ResetToStartingState();
    }

    private void Update()
    {
    }

    public void MoveToPage(GameObject targetPage)
    {
        _pages.ForEach(p => p.SetActive(false));
        targetPage.SetActive(true);
    }

    private void ResetToStartingState()
    {
        _pages.ForEach(p => p.SetActive(false));
        var mainPage = _pages.SingleOrDefault(p => p.name == "Main");
        if (mainPage == null)
        {
            Debug.LogError("There is no page called \"Main\". There must be exactly one page with that name.");
            return;
        }

        mainPage.SetActive(true);
    }
}