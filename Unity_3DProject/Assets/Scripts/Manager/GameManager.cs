using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon<GameManager>
{
    [SerializeField]
    public Transform Player;
    [SerializeField]
    public Transform MainCam;

    public float money = 0;
}
