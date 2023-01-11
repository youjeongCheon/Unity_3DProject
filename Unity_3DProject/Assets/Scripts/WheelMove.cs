using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMove : MonoBehaviour
{
    private Rigidbody rigid;
    private Transform playerTransform;

    [SerializeField]
    private float moveSpeed = 10;
    [SerializeField]
    private float rotateSpeed = 5;

    private void Awake()
    {
        playerTransform = transform.root;
        rigid = playerTransform.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
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
