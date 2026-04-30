using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Miners : MonoBehaviour
{
    [SerializeField] GameObject MinerButton;
    [SerializeField] GameObject MinerText;
    [SerializeField] GameObject FakeMinerButton;
    [SerializeField] int Minercost = 10;
    [SerializeField] int cookiesMadePerMiner = 5;
    public static int NumberOfMiners = 0;
    [SerializeField] GameObject fakeMinerText;

    [SerializeField] float costScaleFactor = 2f;

    [SerializeField] GameObject menuText;

    [SerializeField] float upgradeMinersFactor = 2f;

    public static int MinersUpgradeCost = 300;

    public static int cookiesPersecond = 0;

    bool makingcookie = false;
    private void Start()
    {
        fakeMinerText.GetComponent<Text>().text = "???";
        MinerText.GetComponent<Text>().text = "Miners - " + Minercost;

    }
    private void Update()
    {
        if (Cookies.cookieCount >= Minercost)
        {
            FakeMinerButton.SetActive(false);
        }
        else
        {
            FakeMinerButton.SetActive(true);
        }
        if (!makingcookie)
        {
            StartCoroutine(miner());
        }
       
    }
        public void MakeMiners()
        {
            Cookies.cookieCount -= Minercost;
            NumberOfMiners++;
            cookiesPersecond = NumberOfMiners * cookiesMadePerMiner;
            Minercost = Mathf.RoundToInt(Minercost * costScaleFactor);
            cookiesPersecond += cookiesMadePerMiner;
            fakeMinerText.GetComponent<Text>().text = "Miner - " + Minercost;
            MinerText.GetComponent<Text>().text = "Miner - " + Minercost;
            if (Menu.levelUnlocked == 2)
            {
                Menu.levelUnlocked++;
                menuText.SetActive(true);
            }
        }
        IEnumerator miner()
        {
            makingcookie = true;
            yield return new WaitForSeconds(1);
            Cookies.cookieCount += cookiesPersecond;
            Cookies.totalCookieCount += cookiesPersecond;

            makingcookie = false;
        }
        public void UpgradeMiners()
    {
            cookiesMadePerMiner = Mathf.RoundToInt(cookiesMadePerMiner * upgradeMinersFactor);
            cookiesPersecond = NumberOfMiners * cookiesMadePerMiner;

            Cookies.cookieCount -= MinersUpgradeCost;
            MinersUpgradeCost = Mathf.RoundToInt(MinersUpgradeCost * upgradeMinersFactor);
    }
}















