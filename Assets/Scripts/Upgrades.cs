using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [SerializeField] GameObject UpgradeMenu;
    [SerializeField] GameObject UpgradeMenuButtonText;

    [SerializeField] GameObject autoclickerUpgradeButton;
    [SerializeField] GameObject MinerUpgradeButton;
    [SerializeField] GameObject ChefUpgradeButton;
    [SerializeField] GameObject MilkShakeUpgradeButton;
  



    bool upgradeMenuOpen = false;

    private void Update()
    {
        if(Cookies.cookieCount >= AutoClicker.UpgradeCost)
        {
            autoclickerUpgradeButton.SetActive(true);

        }
        else
        {
            autoclickerUpgradeButton.SetActive(false);  
        }
        if (Cookies.cookieCount >= Miners.MinersUpgradeCost)
        {
            MinerUpgradeButton.SetActive(true);
        }
        else
        {
            MinerUpgradeButton.SetActive(false);
        }
        if (Cookies.cookieCount >= Chef.ChefUpgradeCost)
        {
            ChefUpgradeButton.SetActive(true);
        }
        else
        {
            ChefUpgradeButton.SetActive(false);
        }
        if (Cookies.cookieCount >= MilkShake.milkShakeUpgradeCost)
        {
            MilkShakeUpgradeButton.SetActive(true);
        }
        else
        {
            MilkShakeUpgradeButton.SetActive(false);
        }
       
        
    }
    public void menuButtonPressed()
    {
        if (!upgradeMenuOpen)
        {
            UpgradeMenu.SetActive(true);
            upgradeMenuOpen = true;
            UpgradeMenuButtonText.GetComponent<Text>().text = "Close";
        }
        else
        {
            UpgradeMenu.SetActive(false);
            upgradeMenuOpen = false;
            UpgradeMenuButtonText.GetComponent<Text>().text = "Upgrades";
        }

    }
}
