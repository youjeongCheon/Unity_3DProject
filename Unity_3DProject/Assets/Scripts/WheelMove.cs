using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WheelMove : MonoBehaviour
{
    private Rigidbody rigid;
    [SerializeField]
    private float moveSpeed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        rigid.velocity = -transform.right * Input.GetAxis("Vertical") * moveSpeed;
    }
}
