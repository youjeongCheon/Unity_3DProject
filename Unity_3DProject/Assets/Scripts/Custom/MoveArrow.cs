using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    [SerializeField]
    private Vector3 moveAxis;

    private Vector3 clickPosition;
    private Transform parentTransform;
    private Vector3 distance;

    private void Awake()
    {
        parentTransform = transform.parent;
        transform.position += new Vector3(parentTransform.position.x + 0.5f * parentTransform.lossyScale.x * moveAxis.x,
                                         parentTransform.position.y + 0.5f * parentTransform.lossyScale.y * moveAxis.y,
                                         parentTransform.position.z + 0.5f * parentTransform.lossyScale.z * moveAxis.z);
    }

    private void OnMouseUp()
    {
        // distance √ ±‚»≠
        distance = Vector3.zero;
    }



    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

        int layerMask = 1 << LayerMask.NameToLayer("Arrow");
        if (Physics.Raycast(ray, out hit, Mathf.Infinity,layerMask))
        {
            if (distance == Vector3.zero) distance = parentTransform.position - hit.point;

            if (moveAxis.x != 0)
                parentTransform.position = new Vector3( hit.point.x+distance.x,
                                                        parentTransform.position.y,
                                                        parentTransform.position.z);
            else if (moveAxis.y != 0)
                parentTransform.position = new Vector3( parentTransform.position.x,
                                                        hit.point.y+distance.y,
                                                        parentTransform.position.z);
           else if (moveAxis.z != 0)
                parentTransform.position = new Vector3( parentTransform.position.x,
                                                        parentTransform.position.y,
                                                        hit.point.z+distance.z);
        }
    }
}
