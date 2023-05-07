using System;
using Domain.Projects;
using UnityEngine;

public class ProjectLogic : MonoBehaviour
{
    private Project _projectInfo;
    private string _previousTimeString = "";

    public Project ProjectInfo => _projectInfo;
    public static event Action OnProjectTimeStringChange;

    void Update()
    {
        ProjectInfo.TimeActive += TimeSpan.FromSeconds(Convert.ToDouble(Time.deltaTime));
        if (_previousTimeString != ProjectInfo.TimeActiveAsString)
        {
            OnProjectTimeStringChange?.Invoke();
            _previousTimeString = ProjectInfo.TimeActiveAsString;
        }
    }

    public void Initialize(Project projectInfo)
    {
        _projectInfo = projectInfo;
        gameObject.name = projectInfo.Name;
    }
}