using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMove : MonoBehaviour
{
    private Rigidbody rigid;
    private Transform playerTransform;
    private WheelPartJoint[] wheels;
    private bool hasWheels = false;

    [SerializeField]
    private float moveSpeed = 5;
    [SerializeField]
    private float rotateSpeed = 1;

    private void Start()
    {
        playerTransform = transform.root;
        wheels = GetComponentsInChildren<WheelPartJoint>();
        rigid = playerTransform.GetComponent<Rigidbody>();
        CheckWheel();
    }

    private void FixedUpdate()
    {
        if(hasWheels)
        {
            Move();
            Rotate();
        }
        
    }

    private void CheckWheel()
    {
        if (wheels.Length != 0)
        {
            hasWheels = true;
           
        }
    }

    private void Move()
    {
        rigid.velocity = playerTransform.forward * Input.GetAxis("Vertical") * moveSpeed + Vector3.up * rigid.velocity.y;
    }

    private void Rotate()
    {
        Quaternion dir = Quaternion.Euler(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        playerTransform.rotation *= dir;
    }
}
