using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TabMenuhandler : MonoBehaviour
{
    public List<GameObject> gameMenus;
    public List<Button> menuButtons;
    public GameObject overViewMenu;
    public Color defaultBackgroundColor;
    public Color activeBackgroundColor;
    public Color defaultTextColor;
    public Color activeTextColor;
    private Button selectedMenu;

    private void Start()
    {
        ResetStates();
        gameMenus.Single(menu => menu.name == overViewMenu.name).SetActive(true);
    }

    private void ResetStates()
    {
        gameMenus.ForEach(menu => menu.SetActive(false));

        foreach(Button button in menuButtons)
        {
            var colorBlock = button.colors;
            colorBlock.normalColor = defaultBackgroundColor;
            colorBlock.selectedColor = activeBackgroundColor;
            colorBlock.highlightedColor = defaultBackgroundColor;
            colorBlock.pressedColor = activeBackgroundColor;
            button.colors = colorBlock;

            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().color = defaultTextColor;
        }
    }

    public void Activatebutton(Button button)
    {
        selectedMenu = button;
        

        foreach(GameObject menu in gameMenus)
        {
            if (menu.name == selectedMenu.name)
            {
                if (menu.activeSelf)
                {
                    ResetStates();
                    gameMenus.Single(menu => menu.name == overViewMenu.name).SetActive(true);
                    break;
                }
                menu.SetActive(true);
                menuButtons.Single(button => button.name == menu.name && button.name != overViewMenu.name).GetComponentInChildren<TMPro.TextMeshProUGUI>().color = activeTextColor;
            }
            else
            {
                if (menu.name != overViewMenu.name)
                    menuButtons.Single(button => button.name == menu.name).GetComponentInChildren<TMPro.TextMeshProUGUI>().color = defaultTextColor;
                menu.SetActive(false);
            }
        }
    }
}
