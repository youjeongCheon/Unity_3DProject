using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CustomCamereController : MonoBehaviour
{
    private CinemachineVirtualCamera camera;

    [SerializeField]
    private Transform zeroTransform;

    private Transform target;

    private float xRotateMove, yRotateMove;
    private float scrollWheel;
    private Vector3 dir;
    private Vector3 zoomPosition;

    [SerializeField]
    private float rotateSpeed = 500.0f;
    [SerializeField]
    private float scrollSpeed = 2000.0f;

    private void Awake()
    {
        camera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        setTarget();
        Move();
        Zoom();
    }

    private void setTarget()
    {
        if (CustomManager.Instance.curSelected != null)
        {
            target = CustomManager.Instance.curSelected.transform;
        }
        else if(CustomManager.Instance.preSelected!=null)
        {
            target = CustomManager.Instance.preSelected.transform;
        }
        else
        {
            target = zeroTransform;
        }
        camera.LookAt = target.transform;
    }

    private void Move()
    {
        if (Input.GetMouseButton(1))
        { 
            xRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
            yRotateMove = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;

            Vector3 targetPosition = target.position;

            transform.RotateAround(targetPosition, Vector3.right, -yRotateMove);
            transform.RotateAround(targetPosition, Vector3.up, xRotateMove);
        }
    }

    private void Zoom()
    {
        scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        dir = target.position - transform.position;
        dir = dir.normalized;

        zoomPosition = transform.position + dir * scrollSpeed * scrollWheel * Time.deltaTime;
        transform.position = zoomPosition;
    }

}
        
    
