using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingePartJoint : PartJoint
{
    private UnityEngine.HingeJoint joint;
    private Transform playerTransform;
    private Rigidbody Bodyrigid;

    public override void SetPart()
    {
        base.SetPart();
        playerTransform = transform.root;
        Bodyrigid = playerTransform.GetComponent<Rigidbody>();

        joint = gameObject.AddComponent<UnityEngine.HingeJoint>();
        joint.GetComponent<Joint>().anchor = Vector3.zero;
        joint.GetComponent<Joint>().axis = Vector3.forward;
        joint.GetComponent<Joint>().connectedBody = Bodyrigid;
    }

    protected override void Operate()
    {
        if (Input.GetMouseButton(1))
        {

            rigid.angularVelocity = transform.forward;

        }
        else if (Input.GetMouseButton(0))
        {
            rigid.angularVelocity = -transform.forward;
        }

        else
        {
            rigid.angularVelocity = Vector3.zero;
        }
    }

    public override void ReSetPart()
    {
        base.ReSetPart();
        Destroy(joint);
    }
}
