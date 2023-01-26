using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMoveTest : MonoBehaviour
{
    private Rigidbody rigid;
    private Transform playerTransform;
    

    [SerializeField]
    private float moveSpeed = 5;
    [SerializeField]
    private float rotateSpeed = 1;

    private void Start()
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
