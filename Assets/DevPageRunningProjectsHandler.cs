using System.Collections.Generic;
using System.Linq;
using Domain.Projects;
using Extensions;
using UI.Global;
using UnityEngine;

public class DevPageRunningProjectsHandler : MonoBehaviour
{
    [SerializeField] private GameObject scrollView;
    [SerializeField] private GameObject runningProjectButtonPrefab;

    private ScrollViewHandler _scrollViewHandler;
    private List<ProjectLogic> _projects;

    private void Start()
    {
        var rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        var runningProjectsObject = rootObjects.SingleOrDefault(p => p.name == Globals.Project.RunningProjectsRoot);
        _scrollViewHandler = scrollView.GetComponent<ScrollViewHandler>();
        _projects = runningProjectsObject.GetAllChildren().Select(p => p.GetComponent<ProjectLogic>()).ToList();

        foreach (var project in _projects)
        {
            _scrollViewHandler.AddButtonToBottom(project.ProjectInfo, runningProjectButtonPrefab);
        }
    }

    private void OnEnable()
    {
        RunningProjectsObserver.OnProjectAdding += HandleProjectAddition;
        RunningProjectsObserver.OnProjectRemoval += HandleProjectRemoval;
    }

    private void OnDisable()
    {
        RunningProjectsObserver.OnProjectAdding -= HandleProjectAddition;
        RunningProjectsObserver.OnProjectRemoval -= HandleProjectRemoval;
    }

    private void HandleProjectAddition(List<Project> newProjects)
    {
        Debug.Log("Project has been added");
        foreach (var project in newProjects)
        {
            _scrollViewHandler.AddButtonToBottom(project, runningProjectButtonPrefab);
        }
    }

    private void HandleProjectRemoval(List<Project> removedProjects)
    {
        Debug.Log("Project has been removed.");
    }
}