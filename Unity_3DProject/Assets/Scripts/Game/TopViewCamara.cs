using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopViewCamara : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 min;
    [SerializeField]
    private Vector3 max;
    [SerializeField]
    private float moveTime=0.2f;

    private void Awake()
    {
        target = GameManager.Instance.targert.transform;
    }
    private void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 newCamPos = target.position;
        newCamPos.x = Mathf.Clamp(newCamPos.x, min.x, max.x);
        newCamPos.y = transform.position.y;
        newCamPos.z = Mathf.Clamp(newCamPos.z, min.z, max.z);
        this.transform.position = Vector3.Lerp(transform.position, newCamPos, moveTime);
    }

}
