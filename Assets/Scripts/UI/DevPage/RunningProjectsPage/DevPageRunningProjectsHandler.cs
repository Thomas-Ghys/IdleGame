using System.Collections.Generic;
using System.Linq;
using Domain.Common.DevPagesRecords;
using Domain.Projects;
using UI.DevPage.PageEnums;
using UI.Global;
using UnityEngine;

namespace UI.DevPage.RunningProjectsPage
{
    public class DevPageRunningProjectsHandler : MonoBehaviour
    {
        [SerializeField] private GameObject scrollView;
        [SerializeField] private GameObject runningProjectButtonPrefab;
        [SerializeField] private List<RunningProjectsPageRecord> pages;

        private ScrollViewHandler _scrollViewHandler;

        private void Awake()
        {
            _scrollViewHandler = scrollView.GetComponent<ScrollViewHandler>();
        }

        private void Start()
        {
            ResetPagesToDefaultState();
        }

        private void OnEnable()
        {
            RunningProjectsObserver.OnProjectAdding += HandleProjectAddition;
            RunningProjectsObserver.OnProjectRemoval += HandleProjectRemoval;
            RunningProjectButtonHandler.OnMoveToProjectDetails += MoveToProjectDetailsPage;
        }

        private void OnDisable()
        {
            RunningProjectsObserver.OnProjectAdding -= HandleProjectAddition;
            RunningProjectsObserver.OnProjectRemoval -= HandleProjectRemoval;
            RunningProjectButtonHandler.OnMoveToProjectDetails -= MoveToProjectDetailsPage;
        }

        private void HandleProjectAddition(List<Project> newProjects)
        {
            Debug.Log("Project has been added");
            foreach (var project in newProjects)
            {
                _scrollViewHandler.AddButtonToTop(project, runningProjectButtonPrefab);
            }
        }

        private void HandleProjectRemoval(List<Project> removedProjects)
        {
            Debug.Log("Project has been removed.");
        }

        /// <summary>
        /// The function will set the default state, meaning all the pages will be disabled except for the main page.
        /// </summary>
        private void ResetPagesToDefaultState()
        {
            pages.ForEach(p => p.GameObject.SetActive(false));
            var mainPage = pages.Single(p => p.Name == RunningProjectsPages.Main).GameObject;
            if (mainPage == null)
            {
                Debug.LogError("There is no page called \"Main\". There must be exactly one page with that name.");
                return;
            }

            mainPage.SetActive(true);
        }

        // TODO: Here are 2 ways to move to different pages. One is triggered by an event and the other is
        //  triggered through a unity event, this isn't clean, so come back later to clean up
        public void MoveToPage(GameObject page)
        {
            pages.ForEach(p => p.GameObject.SetActive(false));
            page.SetActive(true);
        }

        private void MoveToProjectDetailsPage(Project project)
        {
            pages.ForEach(p => p.GameObject.SetActive(false));
            var targetPage = pages.Single(p => p.Name == RunningProjectsPages.ProjectDetails).GameObject;
            targetPage.GetComponent<RunningProjectsDetailsHandler>().UpdateActiveProject(project);
            targetPage.SetActive(true);
        }
    }
}