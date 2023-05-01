using Domain.Projects;
using UnityEngine;

public class ProjectLogic : MonoBehaviour
{
    private Project _projectInfo;

    public Project ProjectInfo => _projectInfo;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Initialize(Project projectInfo)
    {
        _projectInfo = projectInfo;
        gameObject.name = projectInfo.Name;
    }
}