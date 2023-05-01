using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Projects;
using Extensions;
using UnityEngine;

public class RunningProjectsObserver : MonoBehaviour
{
    public static event Action<List<Project>> OnProjectAdding;
    public static event Action<List<Project>> OnProjectRemoval;

    private List<GameObject> _previousProjectObjects = new();

    void Update()
    {
        // TODO: Something weird is happening here.
        var currentProjectObjects = gameObject.GetAllChildren().ToList();
        if (_previousProjectObjects.Count < currentProjectObjects.Count)
        {
            var currentProjects = currentProjectObjects.Select(p => p.GetComponent<ProjectLogic>());
            var previousProjects = _previousProjectObjects.Select(p => p.GetComponent<ProjectLogic>());
            var newProjects =
                currentProjects.Where(p => previousProjects.All(o => o.ProjectInfo.Id != p.ProjectInfo.Id));
            OnProjectAdding?.Invoke(newProjects.Select(p => p.ProjectInfo).ToList());
            _previousProjectObjects = currentProjectObjects.ToList();
        }
        else if (_previousProjectObjects.Count > currentProjectObjects.Count)
        {
            var currentProjects = currentProjectObjects.Select(p => p.GetComponent<ProjectLogic>());
            var previousProjects = _previousProjectObjects.Select(p => p.GetComponent<ProjectLogic>());
            var removedProjects =
                previousProjects.Where(p => currentProjects.All(o => o.ProjectInfo.Id != p.ProjectInfo.Id));
            OnProjectRemoval?.Invoke(removedProjects.Select(p => p.ProjectInfo).ToList());
            _previousProjectObjects = currentProjectObjects.ToList();
        }

        _previousProjectObjects = currentProjectObjects.ToList();
    }
}