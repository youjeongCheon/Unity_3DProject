using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HingeJoint : MonoBehaviour
{
    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            
            rigid.angularVelocity = transform.forward;
           
        }
        else if(Input.GetMouseButton(0))
        {
            rigid.angularVelocity = -transform.forward;
        }

        else
        {
            rigid.angularVelocity = Vector3.zero;
        }
        
    }
}
