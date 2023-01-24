using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrientationCam : MonoBehaviour
{
    [SerializeField]
    private Transform mainCam;
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float distance=3f;

    private Vector3 dir;

    private void FixedUpdate()
    {
        dir = -mainCam.forward;
        transform.position = dir * distance;
        transform.LookAt(target.position);
    }
}
