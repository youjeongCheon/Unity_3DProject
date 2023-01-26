using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartJoint : MonoBehaviour
{
    protected Rigidbody rigid;

    public bool isOperate = false;

    [SerializeField]
    protected float operateSpeed;
    [SerializeField]
    protected float min;
    [SerializeField]
    protected float max;

    protected virtual void FixedUpdate()
    {
        if (isOperate)
        {
            Operate();
        }
    }

    public virtual void SetPart()
    {
        rigid = gameObject.AddComponent<Rigidbody>();
        isOperate = true;
        
    }

    protected virtual void Operate()
    {
        
    }

    public virtual void ReSetPart()
    {
        Destroy(rigid);
    }

    protected virtual void Limit()
    {

    }
}
