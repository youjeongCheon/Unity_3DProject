using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    
    private Ray ray;
    private RaycastHit hit;
    private Renderer objectRenderer;

    private void FixedUpdate()
    {
        if(CustomManager.Instance.customState==CustomState.Paint)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                int layerMask = LayerMask.GetMask("Object");
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                {
                    objectRenderer = hit.collider.gameObject.GetComponent<Renderer>();
                    objectRenderer.material = CustomManager.Instance.selectedMaterial;
                }
            }
        }
        
    }

    
}
