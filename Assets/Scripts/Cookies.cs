using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cookies : MonoBehaviour
{
    public static int cookieCount = 0;
    public static int totalCookieCount = 0;
    [SerializeField] int cookiesPerSecond = 0;


    [SerializeField] GameObject cookieCountText;
    [SerializeField] GameObject cookiesPerSecondText;
    void Update()
    {
        UpdateCookiesPerSecond();
        cookieCountText.GetComponent<Text>().text = "Cookies: " + cookieCount;
        cookiesPerSecondText.GetComponent<Text>().text = "Cookies Per second: " + cookiesPerSecond;

       


    }

    private void UpdateCookiesPerSecond()
    {
        cookiesPerSecond = AutoClicker.cookiesPerSecond + Miners.cookiesPersecond + MilkShake.cookiesPersecond + Chef.cookiesPersecond;

    }
}
