using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    [SerializeField]
    private Vector3 moveAxis;
    [SerializeField]
    private float moveSpeed;

    private Vector3 clickPosition;
    private Transform parentTransform;

    private void Awake()
    {
        parentTransform = GetComponentInParent<Transform>();
        transform.position = new Vector3(parentTransform.position.x + 0.5f * parentTransform.lossyScale.x * moveAxis.x,
                                         parentTransform.position.y + 0.5f * parentTransform.lossyScale.y * moveAxis.y,
                                         parentTransform.position.z + 0.5f * parentTransform.lossyScale.z * moveAxis.z);
    }

    private void OnMouseDown()
    {
        clickPosition = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 move = Input.mousePosition;
        Vector3 pos = parentTransform.position;

        pos.x += moveAxis.x * move.x;
        pos.y += moveAxis.y * move.y;
        pos.z += moveAxis.z * move.z;

        parentTransform.position = pos;

        clickPosition = Input.mousePosition;
    }
}
