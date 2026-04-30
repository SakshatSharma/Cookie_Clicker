using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualClick : MonoBehaviour
{
    public static int manualClickIncrease = 1;
    [SerializeField] GameObject clickIncreaseDisplayText;
    [SerializeField] GameObject theCookie;

    [SerializeField] float displayTextRange = 1f;
   public void ClicktheCookie()
    {
       StartCoroutine(ClickCookieCoroutine());

    }

    IEnumerator ClickCookieCoroutine()
    {
        clickIncreaseDisplayText.SetActive(true);
        Vector2 cookiePostion = theCookie.GetComponent<Transform>().position;

        Cookies.cookieCount += manualClickIncrease;
        Cookies.totalCookieCount += manualClickIncrease;

        clickIncreaseDisplayText.GetComponent<Text>().text = manualClickIncrease.ToString();
        clickIncreaseDisplayText.GetComponent<Transform>().position = new Vector2(Random.Range(cookiePostion.x - displayTextRange, cookiePostion.x + displayTextRange), Random.Range(cookiePostion.y - displayTextRange, cookiePostion.y + displayTextRange));

        clickIncreaseDisplayText.GetComponent<Animation>().Play("Display");

        yield return new WaitForSeconds(0.5f);
        clickIncreaseDisplayText.SetActive(false);

    }

}

