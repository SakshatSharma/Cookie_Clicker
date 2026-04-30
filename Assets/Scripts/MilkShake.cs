using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MilkShake : MonoBehaviour
{
    [SerializeField] GameObject MilkShakeButton;
    [SerializeField] GameObject MilkShakeText;
    [SerializeField] GameObject fakeMilkShakeButton;
    [SerializeField] GameObject FakeMilkShakeText;
    [SerializeField] int MilkshakeCost = 100;
    [SerializeField] int CookiesMadePerMilkShake = 70;
    public static int NumberOfMilkshakes = 0;
    [SerializeField] float costScaleFactor = 3f;

    public static int cookiesPersecond = 0;

    [SerializeField] GameObject menuText;

    [SerializeField] float UpgradeMilkShakeScaleFactor = 3f; 

    public static int milkShakeUpgradeCost = 1000;



    bool makingcookies = false;
    private void Start()
    {
        FakeMilkShakeText.GetComponent<Text>().text = "???";
        MilkShakeText.GetComponent<Text>().text = "MilkShake - " + MilkshakeCost;
    }
    private void Update()
    {
        if (Cookies.cookieCount >= MilkshakeCost)
        {
            fakeMilkShakeButton.SetActive(false);
        }
        else
        {
            fakeMilkShakeButton.SetActive(true);
        }
        if (!makingcookies)
        {
            StartCoroutine(MilkShakeCookie());
        }
    }
    public void MakeMilkshake()
    {
        Cookies.cookieCount -= MilkshakeCost;
        NumberOfMilkshakes++;
        cookiesPersecond = NumberOfMilkshakes * CookiesMadePerMilkShake;
        MilkshakeCost = Mathf.RoundToInt(MilkshakeCost * costScaleFactor);
        cookiesPersecond += CookiesMadePerMilkShake;
        FakeMilkShakeText.GetComponent<Text>().text = "MilkShake - " + MilkshakeCost;
        MilkShakeText.GetComponent<Text>().text = "MilkShake - " + MilkshakeCost;
        if (Menu.levelUnlocked == 4)
        {
            Menu.levelUnlocked++;
            menuText.SetActive(true);
        }
    }
    IEnumerator MilkShakeCookie()
    {
        makingcookies = true;
        yield return new WaitForSeconds(1);
        Cookies.cookieCount += cookiesPersecond;
        Cookies.totalCookieCount += cookiesPersecond;

        makingcookies = false;
    }
    public void UpgradeMilkShakes()
    {
        CookiesMadePerMilkShake = Mathf.RoundToInt(CookiesMadePerMilkShake* UpgradeMilkShakeScaleFactor);
        cookiesPersecond = NumberOfMilkshakes * CookiesMadePerMilkShake;

        Cookies.cookieCount -= milkShakeUpgradeCost;
        milkShakeUpgradeCost = Mathf.RoundToInt(milkShakeUpgradeCost * UpgradeMilkShakeScaleFactor);

    }
}

 




