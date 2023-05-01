using System.Collections.Generic;
using System.Linq;
using Domain.Common;
using Domain.Projects;
using UI.DevPage.NewProjectsPage;
using UI.Global;
using UI.Global.Interfaces;
using UnityEngine;

namespace UI.DevPage
{
    public class DevPageHandler : MonoBehaviour, IPageHandler
    {
        private readonly List<GameObject> _pages = new();

        [SerializeField] private GameObject runningProjectPrefab;
        [SerializeField] private List<GameObjectRecord> pages;

        private void Start()
        {
            for (var i = 0; i < gameObject.transform.childCount; i++)
            {
                _pages.Add(gameObject.transform.GetChild(i).gameObject);
            }

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

        private void StartProjectManually(Project project)
        {
            StartProject(project);
            MoveToPage(pages.Single(p => p.Name == DevPages.RunningProjects).GameObject);
        }

        private void StartProject(Project project)
        {
            var rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            var runningProjectsObject = rootObjects.SingleOrDefault(p => p.name == Globals.Project.RunningProjectsRoot);
            if (runningProjectsObject == null)
            {
                Debug.LogError("The RunningProjects game object cannot be found.");
            }
            runningProjectsObject ??= new GameObject
            {
                name = Globals.Project.RunningProjectsRoot
            };

            var newRunningProject = Instantiate(runningProjectPrefab, runningProjectsObject.transform, true);
            newRunningProject.GetComponent<ProjectLogic>().Initialize(project);
        }

        public void CollapseAllPanels()
        {
            // Debug.Log("All panels should be collapsed here.");
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

        /// <summary>
        /// This is where all the event listeners should be added. These events also need to be removed before the script is disabled.
        /// </summary>
        private void EnableDelegates()
        {
            PanelController.OnFocus += CollapseAllPanels;
            NewProjectButtonHandler.OnStartProject += StartProjectManually;
        }

        /// <summary>
        /// This is where all the event listeners should be removed 
        /// </summary>
        private void DisableDelegates()
        {
            PanelController.OnFocus -= CollapseAllPanels;
            NewProjectButtonHandler.OnStartProject -= StartProjectManually;
        }
    }
}