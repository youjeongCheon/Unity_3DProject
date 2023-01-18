using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : SingleTon<UIManager>
{
    [SerializeField]
    public TextMeshProUGUI moneyUI;
    [SerializeField]
    public TextMeshProUGUI timerUI;

    private string strMin;
    private string strSec;

    public void SetMoney(float money)
    {
        moneyUI.text = money.ToString();
    }

    public void SetTime(float min, float sec)
    {
        strMin = min.ToString();
        if (min < 10)
            strMin = "0" + strMin;

        strSec = sec.ToString();
        if (sec < 10)
            strSec = "0" + strSec;

        timerUI.text = strMin + " : " + strSec;
    }
}
