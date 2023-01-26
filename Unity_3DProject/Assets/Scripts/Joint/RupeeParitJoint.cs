using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeParitJoint : PartJoint
{
    [SerializeField]
    private Transform Hand;

    private Vector3 center;
    private Vector3 curScale;
    private Vector3 fixedPosition;

    public override void SetPart()
    {
        isOperate = true;
        fixedPosition = transform.position;
    }

    protected override void Operate()
    {
        curScale = transform.localScale;
        center = transform.position;
        fixedPosition = center - transform.lossyScale.z * 0.5f * transform.forward;
        if (Input.GetMouseButton(0))
        {
            curScale.z -= Time.deltaTime * operateSpeed;
        }

        if (Input.GetMouseButton(1))
        {
            curScale.z += Time.deltaTime * operateSpeed;
        }
        Limit();
        transform.localScale = curScale;
        transform.position = fixedPosition + transform.lossyScale.z * 0.5f * transform.forward;
        Hand.position = transform.position + transform.lossyScale.z * 0.5f * transform.forward + 0.15f * transform.forward;
    }

    protected override void Limit()
    {
        curScale.z = Mathf.Clamp(curScale.z, min, max);
    }
    
}
