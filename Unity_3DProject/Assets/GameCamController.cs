using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class GameCamController : MonoBehaviour
{
    private CinemachineVirtualCamera CM;
    private Transform target;

    private void Start()
    {
        CM = GetComponent<CinemachineVirtualCamera>();
        target = GameObject.Find("Robot").transform;
        CM.Follow = target;
        CM.LookAt = target;
    }
}
