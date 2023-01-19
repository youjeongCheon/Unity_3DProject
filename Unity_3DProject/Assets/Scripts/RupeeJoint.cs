using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeJoint : MonoBehaviour
{
    [SerializeField]
    private float min;
    [SerializeField]
    private float max;
    [SerializeField]
    private float scaleSpeed;
    [SerializeField]
    private Transform Hand;

    private Vector3 center;
    private Vector3 curScale;
    private Vector3 fixedPosition;

    private void Update()
    {
        Operate();
    }

    private void Setting()
    {
        fixedPosition = transform.position;
    }

    private void Operate()
    {
        curScale = transform.localScale;
        center = transform.position; 
        fixedPosition = center - transform.lossyScale.z * 0.5f * transform.forward;
        if (Input.GetMouseButton(0))
        {
            curScale.z -= Time.deltaTime * scaleSpeed;
        }

        if (Input.GetMouseButton(1))
        {
            curScale.z += Time.deltaTime * scaleSpeed;
        }
        Limit();
        transform.localScale = curScale;
        transform.position = fixedPosition + transform.lossyScale.z * 0.5f * transform.forward;
        Hand.position = transform.position + transform.lossyScale.z * 0.5f * transform.forward + 0.075f* transform.forward; 
    }

    private void Limit()
    {
        curScale.z = Mathf.Clamp(curScale.z, min, max);
    }
}
