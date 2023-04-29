using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*public class TabGroup : MonoBehaviour
{
    [HideInInspector]
    public List<> tabButtons;
    [HideInInspector]
    public  selectedTab;
    public List<GameObject> menus;
    public Color nonActiveColor;
    public Color activeColor;
    

    private void Start()
    {
        ResetTabs();
        tabButtons.ForEach(button => button.setBackground(nonActiveColor));
        menus.Single(menu => menu.name == "Overview").SetActive(true);
    }

    public void Subscribe( button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<>();
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
            tabButtons.ForEach(button => button.setBackground(nonActiveColor));
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
                tabButtons.Single(button => button.name == menu.name).setBackground(activeColor);
            }
            else
            {
                menu.SetActive(false);
                tabButtons.Single(button => button.name == menu.name).setBackground(nonActiveColor);
            }
        }
    }
}*/
