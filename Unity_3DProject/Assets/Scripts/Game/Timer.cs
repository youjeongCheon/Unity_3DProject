using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public UnityEvent OnTimeOver;

    private void Awake()
    {
        startTime = Time.time;
        UIManager.Instance.SetTime(min, sec-1);
    }

    private void FixedUpdate()
    {
        TimeSetting();
        if (timer <= 0)
            OnTimeOver?.Invoke();
    }

    private void TimeSetting()
    {
        playTime = Time.time - startTime;
        timer = minTimer * 60 + secTimer+1;
        timer -= playTime;
        min = Mathf.Floor(timer / 60);
        sec = Mathf.Floor(timer % 60);
        min = Mathf.Clamp(min, 0, 59);
        sec = Mathf.Clamp(sec, 0, 59);

        UIManager.Instance.SetTime(min, sec);
    }
}
