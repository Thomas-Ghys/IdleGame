using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public List<GameObject> menus;
    public TabButton selectedTab;

    private void Start()
    {
        ResetTabs();
        menus.Single(menu => menu.name == "Overview").SetActive(true);
    }

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        SetActive();
    }

    private void ResetTabs()
    {
        foreach(GameObject menu in menus)
        {
            menu.SetActive(false);
        }
    }

    private void SetActive()
    {
        foreach (GameObject menu in menus)
        {
            if (menu.name == selectedTab.name)
            {
                if (menu.activeSelf)
                {
                    ResetTabs();
                    menus.Single(menu => menu.name == "Overview").SetActive(true);
                    break;
                }
                menu.SetActive(true);
            }
            else
            {
                menu.SetActive(false);
            }
        }
    }
}
