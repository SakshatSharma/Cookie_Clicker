using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject menuButtonText;

    bool menuOpen = false;
    [SerializeField] GameObject[] menuTextGameObject;

    [SerializeField] string[] MenuText = new string[] { "Total Cookies: ", "Cookies Baked Manually: " , "Number of Auto Clickers: ", "Number of Chefs: ", "Number of MilkShakes: ", "Number of Miners: "};
    [SerializeField] int[] menuTextValues = new int[] { Cookies.totalCookieCount, ManualClick.manualClickIncrease, AutoClicker.NumberOfAutoClickers, Miners.NumberOfMiners, Chef.NumberOfChefs, MilkShake.NumberOfMilkshakes };

    public static int levelUnlocked = 1;

    private void Update()
    {
        menuTextValues = new int[] { Cookies.totalCookieCount, ManualClick.manualClickIncrease, AutoClicker.NumberOfAutoClickers, Miners.NumberOfMiners, Chef.NumberOfChefs,MilkShake.NumberOfMilkshakes};
        for (int i = 0; i <= levelUnlocked; i++)
        {
            menuTextGameObject[i].GetComponent<Text>().text = MenuText[i] + menuTextValues[i];
        }
        
    }
    public void menuButtonPressed()
    {
        if (!menuOpen)
        {
            menu.SetActive(true);
            menuOpen = true;
            menuButtonText.GetComponent<Text>().text = "Close";
        }
        else
        {
            menu.SetActive(false);
            menuOpen = false;
            menuButtonText.GetComponent<Text>().text = "Menu";
        }

    }
}
