using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private Renderer render;
    private Renderer objectRender;
    private Custom hand;

    [SerializeField]
    private Color normal;
    [SerializeField]
    private Color mouseOver;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        objectRender = transform.parent.GetComponent<Renderer>();
        hand = transform.root.GetComponentInChildren<Custom>();
    }

    private void OnMouseOver()
    {
        if(CustomManager.Instance.customState==CustomState.Create)
        {
            render.material.color = mouseOver;
        }
    }

    private void OnMouseExit()
    {
        render.material.color = normal;
    }

    private void OnMouseDown()
    {
        switch (CustomManager.Instance.customState)
        {
            case CustomState.Selet:
                CustomManager.Instance.ChangeSeleted(gameObject.transform.parent.parent.gameObject);
                break;

            case CustomState.Create:
                CustomManager.Instance.CreateObject();
                GameObject curSelected = CustomManager.Instance.curSelected;
                Custom custom = curSelected.GetComponentInChildren<Custom>();
                if (custom.isCreated)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

                    int layerMask = LayerMask.GetMask("Plane");
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                    {
                        Vector3 dir = transform.up;
                        Vector3 createposition = hit.point + dir*0.5f;
                        Quaternion createRotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);

                        curSelected.transform.position = createposition;
                        curSelected.transform.rotation = createRotation;
                        custom.isCreated = false;

                        if(hit.transform.parent.name=="Hand")
                        {
                            hand.childHandList.Add(curSelected);
                            curSelected.GetComponentInChildren<Custom>().isOnHand = true;
                            curSelected.GetComponentInChildren<Custom>().parentHand = hit.transform.parent.gameObject;
                        }
                    }
                    
                    CustomManager.Instance.customState = CustomState.Selet;
                }
                break;
            case CustomState.Paint:
                objectRender.material = CustomManager.Instance.selectedMaterial;
                break;
        }
    }
}
