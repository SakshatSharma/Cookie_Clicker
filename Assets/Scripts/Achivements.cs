using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Achivements : MonoBehaviour
{
    [SerializeField] GameObject AchivementsMenu;
    [SerializeField] GameObject AchivementsMenuButtonText;
    [SerializeField] GameObject AchivementText;
    [SerializeField] GameObject MoreCookiesAchivementText;
    [SerializeField] GameObject somanycookiesText;
    

    bool AchivementMenuOpen = false;

    private void Update()
    {
        if (Cookies.cookieCount >= 100)
        {
            AchivementText.SetActive(true);
            AchivementsMenuButtonText.GetComponent<Text>().color = Color.red;


        }
        else
        {
            AchivementText.SetActive(false);
            
        }
        if (Cookies.cookieCount >= 1000)
        {
            MoreCookiesAchivementText.SetActive(true);
            AchivementsMenuButtonText.GetComponent<Text>().color = Color.blue;
        }
        else
        {
            MoreCookiesAchivementText.SetActive(false);
           
        }
        if (Cookies.cookieCount >= 10000)
        {
            somanycookiesText.SetActive(true);
            AchivementsMenuButtonText.GetComponent<Text>().color = Color.green;
        }
        else
        {
            somanycookiesText.SetActive(false);
            
        }
    }
        public void AchivementsButtonPressed()
    {
        if (!AchivementMenuOpen)
        {
            AchivementsMenu.SetActive(true);
            AchivementMenuOpen = true;
            AchivementsMenuButtonText.GetComponent<Text>().text = "Close";
            

        }
        else
        {
            AchivementsMenu.SetActive(false);
            AchivementMenuOpen = false;
            AchivementsMenuButtonText.GetComponent<Text>().text = "Achivements";
           
        }
        
    }
   
}



