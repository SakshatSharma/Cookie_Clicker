using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;


public class Scenes : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Update()
    {
        if (Cookies.cookieCount >= 20000)
        {
            SceneManager.LoadScene("WinnerScene");
            Cookies.cookieCount = 0;
            Miners.cookiesPersecond = 0;
            Chef.cookiesPersecond = 0;
            MilkShake.cookiesPersecond = 0;
            AutoClicker.cookiesPerSecond = 0;
        }
   

    }
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScreen");
    }
        
    

  
}
