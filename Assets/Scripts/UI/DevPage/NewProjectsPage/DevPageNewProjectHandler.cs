using System.Collections.Generic;
using Domain.Projects;
using UnityEngine;

namespace UI.DevPage.NewProjectsPage
{
    public class DevPageNewProjectHandler : MonoBehaviour
    {
        // This is temporary, This should be set somewhere else. 
        private List<Project> _possibleProjects = new()
        {
            new("Among us", 0, 1, Color.green),
            new("Factorio", 0, 2, Color.yellow)
        };

        [SerializeField] private GameObject expandableButtonPrefab;
        [SerializeField] private GameObject scrollView;
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