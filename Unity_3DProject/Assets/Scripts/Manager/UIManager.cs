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

    [SerializeField]
    private GameObject startUI;
    [SerializeField]
    private GameObject TimeOVerUI;

    [SerializeField]
    private TextMeshProUGUI MoneyUI;
    [SerializeField]
    private TextMeshProUGUI bestMoneyUI;


    private string strMin;
    private string strSec;

    public void GameStart()
    {
        Time.timeScale = 1;
        startUI.SetActive(false);
    }
    public void TimeOver()
    {
        Time.timeScale = 0;
        TimeOVerUI.SetActive(true);
    }

    public void SetScoreTxt()
    {
        GameManager.Instance.SetScore();
        MoneyUI.text = GameManager.Instance.money.ToString();
        bestMoneyUI.text = GameManager.Instance.bestMoney.ToString();
    }

    public void SetMoney()
    {
        moneyUI.text = GameManager.Instance.money.ToString();
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
