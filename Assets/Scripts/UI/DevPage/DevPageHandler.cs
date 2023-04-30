using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DevPageHandler : MonoBehaviour
{
    // This is temporary, This should be set somewhere else. 
    private List<Project> _possibleProjects = new ()
    {
        new ("Among us", 0, 1, Color.green),
        new ("Factorio", 0, 2, Color.yellow)
    };
    
    
    [SerializeField] private GameObject _scrollView;
    private ScrollViewHandler _scrollViewHandler;
    
    [SerializeField] private GameObject _buttonPrefab;
    private readonly List<GameObject> _pages = new ();
    
    private void Start()
    {
        for (var i = 0; i < gameObject.transform.childCount; i++)
        {
            _pages.Add(gameObject.transform.GetChild(i).gameObject);
        }
        
        _scrollViewHandler = _scrollView.GetComponent<ScrollViewHandler>();
        SetPossibleProjects();
        
        ResetPagesToDefaultState();
    }


    public void MoveToPage(GameObject targetPage)
    {
        _pages.ForEach(p => p.SetActive(false));
        targetPage.SetActive(true);
    }

    /// <summary>
    /// The function will set the default state, meaning all the pages will be disabled except for the main page.
    /// </summary>
    private void ResetPagesToDefaultState()
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

    private void SetPossibleProjects()
    {
        foreach (var project in _possibleProjects)
        {
            _scrollViewHandler.AddButtonToBottom(project, _buttonPrefab);
        }
    }
}