using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleArrow : MonoBehaviour
{
    [SerializeField]
    private Vector3 scaleAxis;

    private Transform parentTransform;
    private Vector3 distance;

    private void Awake()
    {
        gameObject.SetActive(false);

        parentTransform = transform.parent;
        transform.position += new Vector3(parentTransform.position.x + 0.5f * parentTransform.lossyScale.x * scaleAxis.x,
                                         parentTransform.position.y + 0.5f * parentTransform.lossyScale.y * scaleAxis.y,
                                         parentTransform.position.z + 0.5f * parentTransform.lossyScale.z * scaleAxis.z);
    }

    private void OnEnable()
    {
        transform.parent = null;
    }

    private void OnDisable()
    {
        transform.parent = parentTransform;
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
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Vector3 scale = parentTransform.localScale;
            if (distance == Vector3.zero) distance = parentTransform.position - hit.point;

           
            if (scaleAxis.x != 0)
            {
                parentTransform.localScale = new Vector3(Mathf.Abs(hit.point.x), scale.y, scale.z);
                transform.position = new Vector3(hit.point.x + distance.x, transform.position.y, transform.position.z);
            }
            else if (scaleAxis.y != 0)
            { 
                parentTransform.localScale = new Vector3(scale.x , Mathf.Abs(hit.point.y), scale.z);
                transform.position = new Vector3(transform.position.x, hit.point.y + distance.y, transform.position.z);
            }

            else if (scaleAxis.z != 0)
            { 
                parentTransform.localScale = new Vector3(scale.x , scale.y, Mathf.Abs(hit.point.z));
                transform.position = new Vector3(transform.position.x, transform.position.y, hit.point.z + distance.z);
            }
           
        }
    }
}
