using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Wheel: MonoBehaviour
{
    private Rigidbody rigid;

    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float moveSpeed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 spin = transform.forward*Input.GetAxis("Vertical") *rotationSpeed;

        rigid.angularVelocity = spin;
        rigid.velocity = -transform.right * Input.GetAxis("Vertical") * moveSpeed;
    }

}