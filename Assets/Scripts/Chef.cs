using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chef : MonoBehaviour
{
    [SerializeField] GameObject ChefButton;
    [SerializeField] GameObject ChefText;
    [SerializeField] GameObject fakeChefButton;
    [SerializeField] GameObject FakeChefText;
    [SerializeField] int ChefCost = 50;
    [SerializeField] int CookiesMadePerChef = 30;
    public static int NumberOfChefs = 0;
    [SerializeField] float costScaleFactor = 1.5f;

    public static int cookiesPersecond = 0;
    [SerializeField] GameObject menuText;

    [SerializeField] float upgradeChefScaleFactor = 2f;

    public static int ChefUpgradeCost = 500;

    bool makingcookie = false;
    private void Start()
    {
        FakeChefText.GetComponent<Text>().text = "???";
        ChefText.GetComponent<Text>().text = "Chef - " + ChefCost;
    }
    private void Update()
    {
        if (Cookies.cookieCount >= ChefCost)
        {
            fakeChefButton.SetActive(false);
        }
        else
        {
            fakeChefButton.SetActive(true);
        }
        if (!makingcookie)
        {
            StartCoroutine(ChefCookie());
        }
    }
    public void MakeChef()
    {
        Cookies.cookieCount -= ChefCost;
        NumberOfChefs++;
        cookiesPersecond = NumberOfChefs * CookiesMadePerChef;
        ChefCost = Mathf.RoundToInt(ChefCost * costScaleFactor);
        cookiesPersecond += CookiesMadePerChef;
        FakeChefText.GetComponent<Text>().text = "Chef - " + ChefCost;
        ChefText.GetComponent<Text>().text = "Chef - " + ChefCost;
        if (Menu.levelUnlocked == 3)
        {
            Menu.levelUnlocked++;
            menuText.SetActive(true);
        }
    }
    IEnumerator ChefCookie()
    {
        makingcookie = true;
        yield return new WaitForSeconds(1);
        Cookies.cookieCount += cookiesPersecond;
        Cookies.totalCookieCount += cookiesPersecond;

        makingcookie = false;
    }
    public void UpgradeChef()
    {
        CookiesMadePerChef = Mathf.RoundToInt(CookiesMadePerChef * upgradeChefScaleFactor);
        cookiesPersecond = NumberOfChefs * CookiesMadePerChef;

        Cookies.cookieCount -= ChefUpgradeCost;
        ChefUpgradeCost = Mathf.RoundToInt(ChefUpgradeCost * upgradeChefScaleFactor);
       
    }
}

      
    

