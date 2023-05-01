using Domain.Projects;
using UnityEngine;

public class ProjectLogic : MonoBehaviour
{
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
        gameObject.name = projectInfo.Name;
    }
}