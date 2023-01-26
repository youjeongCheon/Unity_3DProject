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
        target = GameManager.Instance.targert.transform;
        CM.Follow = target;
        CM.LookAt = target;
    }
}
