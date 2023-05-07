using System.Collections.Generic;
using Domain.Common;
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
            new("Among us", new ProjectFractionRequirement(0, 1), Color.green)
            {
                Stats = new List<ProjectStat>
                {
                    new("Features", 14, MeasurementTypes.Number),
                    new("Known Bugs", 2, MeasurementTypes.Number),
                    new("Testing Coverage", 87, MeasurementTypes.Percentage),
                    new("Feature backlog", 19, MeasurementTypes.Number)
                }
            },
            new("Factorio", new ProjectFractionRequirement(0, 2), Color.yellow)
            {
                Stats = new List<ProjectStat>
                {
                    new("Features", 49, MeasurementTypes.Number),
                    new("Known Bugs", 58, MeasurementTypes.Number),
                    new("Testing Coverage", 8, MeasurementTypes.Percentage),
                    new("Feature backlog", 97, MeasurementTypes.Number)
                }
            }
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