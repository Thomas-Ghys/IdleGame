using System.Collections.Generic;
using System.Linq;
using Domain.Common.DevPagesRecords;
using Domain.Projects;
using Extensions;
using UI.DevPage.PageEnums;
using UI.DevPage.RunningProjectsPage;
using UI.Global;
using UnityEngine;

public class DevPageRunningProjectsHandler : MonoBehaviour
{
    [SerializeField] private GameObject scrollView;
    [SerializeField] private GameObject runningProjectButtonPrefab;
    [SerializeField] private List<RunningProjectsPageRecord> pages;

    private ScrollViewHandler _scrollViewHandler;
    private List<ProjectLogic> _projects;

    private void Awake()
    {
        _scrollViewHandler = scrollView.GetComponent<ScrollViewHandler>();
    }
    
    private void Start()
    {
        var rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        var runningProjectsObject = rootObjects.SingleOrDefault(p => p.name == Globals.Project.RunningProjectsRoot);
        _projects = runningProjectsObject.GetAllChildren().Select(p => p.GetComponent<ProjectLogic>()).ToList();
        ResetPagesToDefaultState();
    }

    private void OnEnable()
    {
        RunningProjectsObserver.OnProjectAdding += HandleProjectAddition;
        RunningProjectsObserver.OnProjectRemoval += HandleProjectRemoval;
        RunningProjectButtonHandler.OnMoveToProjectDetails += MoveToProjectDetailsPage;
    }

    private void OnDisable()
    {
        RunningProjectsObserver.OnProjectAdding -= HandleProjectAddition;
        RunningProjectsObserver.OnProjectRemoval -= HandleProjectRemoval;
        RunningProjectButtonHandler.OnMoveToProjectDetails -= MoveToProjectDetailsPage;
    }

    private void MoveToProjectDetailsPage(Project project)
    {
        Debug.Log("hihi");
        pages.ForEach(p => p.GameObject.SetActive(false));
        pages.Single(p => p.Name == RunningProjectsPages.ProjectDetails).GameObject.SetActive(true);
    }

    private void HandleProjectAddition(List<Project> newProjects)
    {
        Debug.Log("Project has been added");
        foreach (var project in newProjects)
        {
            _scrollViewHandler.AddButtonToTop(project, runningProjectButtonPrefab);
        }
    }

    private void HandleProjectRemoval(List<Project> removedProjects)
    {
        Debug.Log("Project has been removed.");
    }

    /// <summary>
    /// The function will set the default state, meaning all the pages will be disabled except for the main page.
    /// </summary>
    private void ResetPagesToDefaultState()
    {
        pages.ForEach(p => p.GameObject.SetActive(false));
        var mainPage = pages.Single(p => p.Name == RunningProjectsPages.Main).GameObject;
        if (mainPage == null)
        {
            Debug.LogError("There is no page called \"Main\". There must be exactly one page with that name.");
            return;
        }

        mainPage.SetActive(true);
    }
}