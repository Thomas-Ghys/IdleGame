using System.Collections.Generic;
using Domain.Projects;
using UI.Global;
using UnityEngine;

namespace UI.DevPage.NewProjectsPage
{
    public class DevPageNewProjectHandler : MonoBehaviour
    {
        // This is temporary, This should be set somewhere else. 
        private List<Project> _possibleProjects = new()
        {
            new("Among us", new ProjectFractionRequirement(0, 1), Color.green),
            new("Factorio", new ProjectFractionRequirement(0, 2), Color.yellow)
        };

        [SerializeField] private GameObject scrollView;
        [SerializeField] private GameObject expandableButtonPrefab;
        private ScrollViewHandler _scrollViewHandler;

        private void Start()
        {
            _scrollViewHandler = scrollView.GetComponent<ScrollViewHandler>();
            SetPossibleProjects();
        }

        private void SetPossibleProjects()
        {
            foreach (var project in _possibleProjects)
            {
                _scrollViewHandler.AddButtonToBottom(project, expandableButtonPrefab);
            }
        }
    }
}