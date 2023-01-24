using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon<GameManager>
{
    [SerializeField]
    public Transform Player;
    [SerializeField]
    public Transform MainCam;

    public GameObject robot;

    public float money = 0;

    private void Start()
    {
        robot = CustomManager.Instance.robot;
        robot.transform.position = Player.transform.position;

    }
}
