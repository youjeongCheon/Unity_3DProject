using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CustomCamereController : MonoBehaviour
{
    private CinemachineVirtualCamera Camera;

    [SerializeField]
    private GameObject target;

    private float xRotateMove, yRotateMove;

    [SerializeField]
    private float rotateSpeed = 500.0f;
    [SerializeField]
    private float scrollSpeed = 2000.0f;

    private void Awake()
    {
        Camera = GetComponent<CinemachineVirtualCamera>();
        Camera.LookAt = target.transform;
        
    }

    private void Update()
    {
        Move();
        Zoom();
        Limit();
    }

    private void setTarget()
    {
        if (CustomManager.Instance.curSelected != null)
            target = CustomManager.Instance.curSelected;

        Debug.Log(target.name);
    }

    private void Move()
    {
        if (Input.GetMouseButton(1))
        {
            setTarget();

            xRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
            yRotateMove = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;

            Vector3 targetPosition = target.transform.position;

            transform.RotateAround(targetPosition, Vector3.right, -yRotateMove);
            transform.RotateAround(targetPosition, Vector3.up, xRotateMove);
        }
    }

    private void Zoom()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        Camera.m_Lens.FieldOfView += scrollWheel * Time.deltaTime * scrollSpeed;
    }

    private void Limit()
    {
        if (transform.position.y < 1)
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);

        if(Camera.m_Lens.FieldOfView<10|| Camera.m_Lens.FieldOfView>50)
            Camera.m_Lens.FieldOfView= Mathf.Clamp(Camera.m_Lens.FieldOfView, 10, 50);
    }
}
        
    
