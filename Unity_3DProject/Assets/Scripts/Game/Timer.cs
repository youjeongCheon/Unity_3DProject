using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField]
    private float minTimer;
    [SerializeField]
    private float secTimer;
    private float timer;
    private float playTime;
    private float startTime;
    private float min;
    private float sec;
   

    private void Awake()
    {
        startTime = Time.time;
    }

    private void FixedUpdate()
    {
        TimeSetting();
    }

    private void TimeSetting()
    {
        playTime = Time.time - startTime;
        timer = minTimer * 60 + secTimer;
        timer -= playTime;
        min = Mathf.Floor(timer / 60);
        sec = Mathf.Floor(timer % 60)+1;

        UIManager.Instance.SetTime(min, sec);
    }
}
