using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HingeJoint : MonoBehaviour
{
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            
            rigidbody.angularVelocity = transform.forward;
           
        }
        else if(Input.GetMouseButton(1))
        {
            rigidbody.angularVelocity = -transform.forward;
        }

        else
        {
            rigidbody.angularVelocity = Vector3.zero;
        }
        
    }
}
