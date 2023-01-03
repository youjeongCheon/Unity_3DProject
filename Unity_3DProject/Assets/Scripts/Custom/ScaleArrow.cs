using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleArrow : MonoBehaviour
{
    [SerializeField]
    private Vector3 scaleAxis;
    [SerializeField]
    private Transform oppositeArrow;

    private Transform beginningTranstorm;
    private Transform parentTransform;
    private Transform GFX;

    private void Awake()
    {
        beginningTranstorm = transform;
        gameObject.SetActive(false);
        parentTransform = transform.parent.parent;
        GFX = parentTransform.GetChild(0);
        transform.position = beginningTranstorm.position + new Vector3(parentTransform.position.x + 0.5f * GFX.localScale.x * scaleAxis.x,
                                                                      parentTransform.position.y + 0.5f * GFX.localScale.y * scaleAxis.y,
                                                                      parentTransform.position.z + 0.5f * GFX.localScale.z * scaleAxis.z);
    }

    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

        int layerMask = 1 << LayerMask.NameToLayer("Arrow");
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))

        {
            Vector3 scale = GFX.localScale;
            Vector3 distane = hit.point - parentTransform.position;
           
            if (scaleAxis.x != 0)
            {

                GFX.localScale = new Vector3(Mathf.Abs(distane.x*2)-0.8f, scale.y, scale.z);
                transform.position = new Vector3(hit.point.x, transform.position.y, transform.position.z);
                oppositeArrow.position= new Vector3(parentTransform.position.x-Mathf.Abs(distane.x)*scaleAxis.x, transform.position.y, transform.position.z);
            }
            else if (scaleAxis.y != 0)
            {
                GFX.localScale = new Vector3(scale.x , Mathf.Abs(distane.y * 2) - 0.8f, scale.z);
                transform.position = new Vector3(transform.position.x, hit.point.y , transform.position.z);
                oppositeArrow.position = new Vector3(transform.position.x, parentTransform.position.y - Mathf.Abs(distane.y) * scaleAxis.y, transform.position.z);
            }

            else if (scaleAxis.z != 0)
            {
                GFX.localScale = new Vector3(scale.x , scale.y, Mathf.Abs(distane.z * 2) - 0.8f);
                transform.position = new Vector3(transform.position.x, transform.position.y, hit.point.z );
                oppositeArrow.position = new Vector3(transform.position.x, transform.position.y, parentTransform.position.z - Mathf.Abs(distane.z) * scaleAxis.z);
            }
           
        }
    }
}
