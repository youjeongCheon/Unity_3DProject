using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel: MonoBehaviour
{
    private Rigidbody rigid;

    [SerializeField]
    private float rotationSpeed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 spin = transform.forward*Input.GetAxis("Vertical") *rotationSpeed;

        rigid.angularVelocity = spin;
        
    }

}