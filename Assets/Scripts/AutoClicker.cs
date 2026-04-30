using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoClicker : MonoBehaviour
{
    //UI GameObject
    [SerializeField] GameObject realButton;
    [SerializeField] GameObject fakeButton;

    [SerializeField] GameObject realButtonText;
    [SerializeField] GameObject fakeButtonText;

    [SerializeField] GameObject menuText;

    //AutoClicker Variables 
    [SerializeField] int autoClickerCost = 5;
    public static int NumberOfAutoClickers = 0;
    [SerializeField] int cookiesMadePerAutoClicker = 1;

    //Upgrade Variables
    public static int UpgradeCost = 100;
    [SerializeField] float upgradesAutoClickerScaleFactor = 2f;
    
    [SerializeField] float costScaleFactor = 2f; 

    public static int cookiesPerSecond = 0; 

    bool makingCookies = false;
    private void Start()
    {
        fakeButtonText.GetComponent<Text>().text = "???";
        realButtonText.GetComponent<Text>().text = "AutoClicker - " + autoClickerCost;
    }
    private void Update()
    {
        if (Cookies.cookieCount >= autoClickerCost)
        {
            fakeButton.SetActive(false);

        }
        else
        {
            fakeButton.SetActive(true);
        }
        if (!makingCookies)
        {
            StartCoroutine(Autoclick());
        }
        

    }
    public void MakeAutoClicker()
    {
        Cookies.cookieCount -= autoClickerCost;
        NumberOfAutoClickers++;
        cookiesPerSecond = NumberOfAutoClickers * cookiesMadePerAutoClicker;
        autoClickerCost = Mathf.RoundToInt(autoClickerCost * costScaleFactor);
        fakeButtonText.GetComponent<Text>().text = "AutoClicker - " + autoClickerCost;
        realButtonText.GetComponent<Text>().text = "AutoClicker - " + autoClickerCost;
        if (Menu.levelUnlocked == 1) 
        {
            Menu.levelUnlocked++;
            menuText.SetActive(true);
        }
    }
    IEnumerator Autoclick()
    {
        makingCookies = true;
        yield return new WaitForSeconds(1);
        Cookies.cookieCount += cookiesPerSecond;
        Cookies.totalCookieCount += cookiesPerSecond;

        makingCookies = false;

    }
    public void UpgradeAutoClicker()
    {
        cookiesMadePerAutoClicker = Mathf.RoundToInt(cookiesMadePerAutoClicker * upgradesAutoClickerScaleFactor);
        cookiesPerSecond = NumberOfAutoClickers * cookiesMadePerAutoClicker;

        Cookies.cookieCount -= UpgradeCost;
        UpgradeCost = Mathf.RoundToInt(UpgradeCost * upgradesAutoClickerScaleFactor);
    }


}

