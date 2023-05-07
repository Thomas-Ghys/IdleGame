using Domain.Projects;
using Domain.Projects.Interfaces;
using TMPro;
using UI.Global;
using UnityEngine;

namespace UI.DevPage.RunningProjectsPage
{
    public class RunningProjectsDetailsHandler : MonoBehaviour
    {
        [SerializeField] private GameObject scrollView;
        [SerializeField] private GameObject runningProjectStatButtonPrefab;
        [SerializeField] private TextMeshProUGUI pageHeaderText;

        private ScrollViewHandler _scrollViewHandler;
        private Project _project;

        private void Awake()
        {
            _scrollViewHandler = scrollView.GetComponent<ScrollViewHandler>();
        }

        public void UpdateActiveProject(IButtonInfo buttonInfo)
        {
            var previousProjectId = _project?.Id;
            _project = buttonInfo as Project;
            pageHeaderText.text = _project!.Name;

            if (previousProjectId == null || _project.Id != previousProjectId)
            {
                _scrollViewHandler.ClearButtons();
                foreach (var stat in _project.Stats)
                {
                    _scrollViewHandler.AddButtonToBottom(stat, runningProjectStatButtonPrefab);
                }
            }
        }
    }
}