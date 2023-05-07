using Domain.Projects;
using Domain.Projects.Interfaces;
using TMPro;
using UI.Global;
using UnityEngine;

public class RunningProjectsDetailsHandler : MonoBehaviour
{
    [SerializeField] private GameObject scrollView;
    [SerializeField] private GameObject scrollViewContent;
    [SerializeField] private GameObject runningProjectStatButtonPrefab;
    [SerializeField] private TextMeshProUGUI pageHeaderText;

    private ScrollViewHandler _scrollViewHandler;
    private Project _project;

    private void Awake()
    {
        _scrollViewHandler = scrollView.GetComponent<ScrollViewHandler>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateActiveProject(IButtonInfo buttonInfo)
    {
        var previousProjectId = _project?.Id;
        _project = buttonInfo as Project;
        pageHeaderText.text = _project.Name;

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