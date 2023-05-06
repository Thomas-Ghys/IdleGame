using Domain.Projects;
using UI.Global;
using UnityEngine;

public class DevPageRunningProjectsDetailsHandler : MonoBehaviour
{
    [SerializeField] private GameObject scrollView;
    [SerializeField] private GameObject runningProjectStatButtonPrefab;

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

    public void Initialize(Project project)
    {
        _project = project;

        foreach (var stat in project.Stats)
        {
            _scrollViewHandler.AddButtonToBottom(project, runningProjectStatButtonPrefab);
        }
    }
}