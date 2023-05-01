using System.Collections.Generic;
using System.Linq;
using Domain.Projects;
using UI.Global;
using UI.Global.Interfaces;
using UnityEngine;

namespace UI.DevPage.NewProjectsPage
{
    public class DevPageHandler : MonoBehaviour, IPageHandler
    {
        // This is temporary, This should be set somewhere else. 
        private List<Project> _possibleProjects = new()
        {
            new("Among us", 0, 1, Color.green),
            new("Factorio", 0, 2, Color.yellow)
        };


        [SerializeField] private GameObject scrollView;
        private ScrollViewHandler _scrollViewHandler;

        [SerializeField] private GameObject buttonPrefab;
        private readonly List<GameObject> _pages = new();

        [SerializeField] private GameObject runningProjectPrefab;

        private void Start()
        {
            for (var i = 0; i < gameObject.transform.childCount; i++)
            {
                _pages.Add(gameObject.transform.GetChild(i).gameObject);
            }

            _scrollViewHandler = scrollView.GetComponent<ScrollViewHandler>();
            SetPossibleProjects();

            ResetPagesToDefaultState();
        }

        private void OnEnable()
        {
            EnableDelegates();
        }

        private void OnDisable()
        {
            DisableDelegates();
        }

        public void MoveToPage(GameObject targetPage)
        {
            _pages.ForEach(p => p.SetActive(false));
            targetPage.SetActive(true);
        }

        private void StartProject(Project project)
        {
            Debug.Log("Starting Project: " + project.Name);
            var rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            var runningProjectsObject = rootObjects.SingleOrDefault(p => p.name == Globals.Project.RunningProjectsRoot);
            runningProjectsObject ??= new GameObject
            {
                name = Globals.Project.RunningProjectsRoot
            };

            var newRunningProject = Instantiate(runningProjectPrefab, runningProjectsObject.transform, true);
            newRunningProject.GetComponent<ProjectLogic>().Initialize(project);
        }

        public void CollapseAllPanels()
        {
            Debug.Log("All panels should be collapsed here.");
        }

        /// <summary>
        /// The function will set the default state, meaning all the pages will be disabled except for the main page.
        /// </summary>
        private void ResetPagesToDefaultState()
        {
            _pages.ForEach(p => p.SetActive(false));
            var mainPage = _pages.SingleOrDefault(p => p.name == "Main");
            if (mainPage == null)
            {
                Debug.LogError("There is no page called \"Main\". There must be exactly one page with that name.");
                return;
            }

            mainPage.SetActive(true);
        }

        private void SetPossibleProjects()
        {
            foreach (var project in _possibleProjects)
            {
                _scrollViewHandler.AddButtonToBottom(project, buttonPrefab);
            }
        }

        /// <summary>
        /// This is where all the event listeners should be added. These events also need to be removed before the script is disabled.
        /// </summary>
        private void EnableDelegates()
        {
            PanelController.OnFocus += CollapseAllPanels;
            ProjectButtonHandler.OnStartProject += StartProject;
        }

        /// <summary>
        /// This is where all the event listeners should be removed 
        /// </summary>
        private void DisableDelegates()
        {
            PanelController.OnFocus -= CollapseAllPanels;
            ProjectButtonHandler.OnStartProject -= StartProject;
        }
    }
}